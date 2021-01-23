    /// <summary>
    /// Holds a list of references to Timers; and provides typed objects to reference the Timer and its
    /// State from within a TypedCallback. Synchronized. Usage:
    /// <code>
    /// TypedStateTimers myTimers = new TypedStateTimers(3);
    /// public void MyMethod() {
    ///     typedStateTimers.Create("Hello, from Timer", new TypedCallback<string>((sr) => {
    ///         System.Console.WriteLine(sr.State); // "Hello, from Timer"
    ///         sr.Dispose(); // Invoke the StateRef method to ensure references are released
    ///     })).Start(1500, Timeout.Infinite);
    /// }
    /// </code>
    /// </summary>
    public class TypedStateTimers
    {
    	/// <summary>
    	/// A typed delegate used as the callback when Timers are created.
    	/// </summary>
    	public delegate void TypedCallback<T>(StateRef<T> state);
    	
    	
    	/// <summary>
    	/// Wraps a Timer and State object to be used from within a TypedCallback.
    	/// </summary>
    	public class StateRef<T> : IDisposable
    	{
    		/// <summary>The state passed into TypedStateTimers.Create. May be null.</summary>
    		public T State { get; internal set; }
    		
    		/// <summary>The Timer: initially not started. Not null.</summary>
    		public System.Threading.Timer Timer { get; internal set; }
    		
    		/// <summary>The TypedStateTimers instance that created this object. Not null.</summary>
    		public TypedStateTimers Parent { get; internal set; }
    		
    		
    		/// <summary>
    		/// A reference to this object is retained; and then Timer's dueTime and period are changed
    		/// to the arguments.
    		/// </summary>
    		public void Start(int dueTime, int period) {
    			lock (Parent.Treelock) {
    				Parent.Add(this);
    				Timer.Change(dueTime, period);
    			}
    		}
    		
    		/// <summary>Disposes the Timer; and releases references to Timer, State, and this object.</summary>
    		public void Dispose() {
    			lock (Parent.Treelock) {
    				if (Timer == null) return;
    				Timer.Dispose();
    				Timer = null;
    				State = default(T);
    				Parent.Remove(this);
    			}
    		}
    	}
    	
    	
    	internal readonly object Treelock = new object();
    	private readonly List<IDisposable> stateRefs;
    	
    	
    	/// <summary>
    	/// Constructs an instance with an internal List of StateRef references set to the initialCapacity.
    	/// </summary>
    	public TypedStateTimers(int initialCapacity) {
    		stateRefs = new List<IDisposable>(initialCapacity);
    	}
    	
    	
    	/// <summary>Invoked by the StateRef to add it to our List. Not Synchronized.</summary>
    	internal void Add<T>(StateRef<T> stateRef) {
    		stateRefs.Add(stateRef);
    	}
    	
    	/// <summary>Invoked by the StateRef to remove it from our List. Not synchronized.</summary>
    	internal void Remove<T>(StateRef<T> stateRef) {
    		stateRefs.Remove(stateRef);
    	}
    	
    	/// <summary>
    	/// Creates a new StateRef object containing state and a new Timer that will use the callback and state.
    	/// The Timer will initially not be started. The returned object will be passed into the callback as its
    	/// argument. Start the Timer by invoking StateRef.Start. Dispose the Timer, and release references to it,
    	/// state, and the StateRef by invoking StateRef.Dispose. No references are held on the Timer, state or
    	/// the StateRef until StateRef.Start is invoked. See the class documentation for a usage example.
    	/// </summary>
    	public StateRef<T> Create<T>(T state, TypedCallback<T> callback) {
    		StateRef<T> stateRef = new StateRef<T>();
    		stateRef.Parent = this;
    		stateRef.State = state;
    		stateRef.Timer = new System.Threading.Timer(
    				new TimerCallback((s) => { callback.Invoke((StateRef<T>) s); }),
    				stateRef, Timeout.Infinite, Timeout.Infinite);
    		return stateRef;
    	}
    	
    	/// <summary>Disposes all current StateRef instances; and releases all references.</summary>
    	public void DisposeAll() {
    		lock (Treelock) {
    			IDisposable[] refs = stateRefs.ToArray();
    			foreach (IDisposable stateRef in refs) stateRef.Dispose();
    		}
    	}
    }

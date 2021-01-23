        public abstract class RecursiveEnumerator : IEnumerator {
        	public RecursiveEnumerator(ICollection collection) {
        		this.collection = collection;
        		this.enumerator = collection.GetEnumerator();
        	}
        	protected abstract ICollection GetChildCollection(object item);
        	public bool MoveNext() {
        		if (enumerator.Current != null) {
        			ICollection child_collection = GetChildCollection(enumerator.Current);
        			if (child_collection != null && child_collection.Count > 0) {
        				stack.Push(enumerator);
        				enumerator = child_collection.GetEnumerator();
        			}
        		}
        		while (!enumerator.MoveNext()) {
        			if (stack.Count == 0) return false;
        			enumerator = stack.Pop();
        		}
        		return true;
        	}
        	public virtual void Dispose() { }
        	public object Current { get { return enumerator.Current; } }
        	public void Reset() {
        		stack.Clear();
        		enumerator = collection.GetEnumerator();
        	}
        	private IEnumerator enumerator;
        	private Stack<IEnumerator> stack = new Stack<IEnumerator>();
        	private ICollection collection;
        }

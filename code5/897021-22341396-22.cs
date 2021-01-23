	public class BaseManager<T> {
		public Dictionary<string, T> Registered { get; set; }
	}
	public interface IBaseManager<T> {
		BaseManager<T> Base { get; set; }
	}
	public class ConcreteManager 
		: IBaseManager<ConcreteManaged> {
		public BaseManager<ConcreteManaged> Base { get; set; }
		public void Refresh() { Console.WriteLine("Refresh() called"); }
	}
	public class BaseManaged<T> {
		public string Name { get; set; }
		public T Manager { get; set; }
	}
	public interface IBaseManaged<T> { 
		BaseManaged<T> Base { get; set; }
	}
	
	public class ConcreteManaged 
		: IBaseManaged<ConcreteManager> {
		public BaseManaged<ConcreteManager> Base { get; set; }
		internal ConcreteManaged () { }
		public void Process () {
			Base.Manager.Refresh ();
		}
	}
	interface IManagerFactory<TManager, TManaged> 
	where TManager : IBaseManager<TManaged>
	where TManaged : IBaseManaged<TManager> {
		TManager Manager { get; }
		TManaged Create (string name);
	}
	public abstract class BaseManagerFactory<TManager, TManaged> 
	: IManagerFactory<TManager, TManaged> 
	where TManager : IBaseManager<TManaged>, new() 
	where TManaged : IBaseManaged<TManager>, new() {
		TManager manager = new TManager();
		public BaseManagerFactory() {
			manager.Base = new BaseManager<TManaged>();
			manager.Base.Registered = new Dictionary<string, TManaged>();
		}
		public TManager Manager { get { return manager; } }
		public TManaged Create (string name) {
			TManaged result = new TManaged();
			result.Base = new BaseManaged<TManager>();
			result.Base.Name = name;
			manager.Base.Registered.Add (name, result);
			result.Base.Manager = manager;
			return result;
		}
	}

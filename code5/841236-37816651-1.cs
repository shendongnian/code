	/// <summary>
	/// The standard web api dependency resolver cannot inject dependencies into a controller 
	/// use this as a simple makeshift IoC
	/// </summary>
	public class OverriddenWebApiDependencyResolver : WebApiOverrideDependency<IDependencyResolver >, IDependencyResolver {
		public OverriddenWebApiDependencyResolver Add(Type serviceType, Func<object> initializer) {
			provided.Add(serviceType, initializer);
			return this;
		}
		public IDependencyScope BeginScope() => new Scope(inner.BeginScope(), provided);
		public OverriddenWebApiDependencyResolver(IDependencyResolver inner) : base(inner, new Dictionary<Type, Func<object>>()) { }
		public class Scope : WebApiOverrideDependency<IDependencyScope>, IDependencyScope {
			public Scope(IDependencyScope inner, IDictionary<Type, Func<object>> provided) : base(inner, provided) { }
		}
	}
	public abstract class WebApiOverrideDependency<T> : IDependencyScope where T : IDependencyScope {
		public void Dispose() => inner.Dispose();
		public Object GetService(Type serviceType) {
			Func<Object> res;
			return provided.TryGetValue(serviceType, out res) ? res() : inner.GetService(serviceType);
		}
		public IEnumerable<Object> GetServices(Type serviceType) {
			Func<Object> res;
			return inner.GetServices(serviceType).Concat(provided.TryGetValue(serviceType, out res) ? new[] { res()} : Enumerable.Empty<object>());
		}
		protected readonly T inner;
		protected readonly IDictionary<Type, Func<object>> provided;
		public WebApiOverrideDependency(T inner, IDictionary<Type, Func<object>> provided) {
			this.inner = inner;
			this.provided = provided;
		}
	}

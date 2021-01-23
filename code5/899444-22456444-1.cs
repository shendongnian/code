	public class DummyViewModelFactory : IViewModelFactory
	{
		private readonly Dictionary<Type, Func<object>> _registredCreators = new Dictionary<Type, Func<object>>();
		public T Create<T>() where T : PropertyChangedBase
		{
			return Create(typeof(T)) as T;
		}
		public object Create(Type type)
		{
			if (type == null)
			{
				return null;
			}
			if (_registredCreators.ContainsKey(type))
			{
				return _registredCreators[type]();
			}
			return null;
		}
		public void Release(object instance)
		{
		}
		public void RegisterCreatorFor<T>(Func<T> creatorFunction)
		{
			_registredCreators.Add(typeof(T), () => creatorFunction());
		}
	}

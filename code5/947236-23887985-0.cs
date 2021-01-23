	public class Randomizer
	{
		private Dictionary<Type, Delegate> _randoms
			= new Dictionary<Type, Delegate>();
		
		public void Add<T>(Func<T> generate)
		{
			_randoms.Add(typeof(T), generate);
		}
		
		public T RandomizeParamValue<T>()
		{
			return ((Func<T>)_randoms[typeof(T)])();
		}
	}

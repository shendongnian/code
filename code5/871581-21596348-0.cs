    public class GenericItem<T>
    {
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public GenericItem(){}
        public GenericItem(T _data)
        {
            data = _data;
        }
		private Dictionary<Type, Delegate> operations =
			new Dictionary<Type, Delegate>()
			{
				{ typeof(int), (Func<int, int, int>)((x, y) => x * y) },
				{ typeof(string), (Func<string, string, string>)((x, y) => x + " " + y) },
			};
		
        public T returnCounterMultiply(T value)
        {
			if (operations.ContainsKey(typeof(T)))
			{
				var operation = (Func<T, T, T>)(operations[typeof(T)]);
				return operation(data, value);
			}
            return value;
        }
    }

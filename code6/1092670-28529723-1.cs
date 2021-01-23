	public class ReflectionHelper<T>
        : IEnumerable<string>
	{
		private string[] _properties;
		private IEnumerable<T> _list;
		
		public ReflectionHelper(IEnumerable<T> list, string[] properties)
		{
			_properties = properties;
			_list = list;
		}
		
		public ReflectionHelper<T> Prop(string property)
		{
			return new ReflectionHelper<T>(_list, _properties.Concat(new string[]{ property}).ToArray());
		}
		
        public ReflectionHelper<T> Prop(string property)
        {
            return new ReflectionHelper<T>(_list, _properties.Concat(new string[] { property }).ToArray());
        }
        public static implicit operator List<string>(ReflectionHelper<T> helper)
        {
            return helper._list.Select(item => string.Join(",",
                            (from p in helper._properties
                             select typeof(T).GetProperty(p).GetValue(item, null)).ToArray())).ToList();
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _list.Select(item => string.Join(",",
                                                    (from p in _properties
                                                     select typeof (T).GetProperty(p).GetValue(item, null)).ToArray()))
                        .GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static class ReflectionHelperExtension
    {
        public static ReflectionHelper<T> Prop<T>(this IEnumerable<T> items, string property)
        {
            return new ReflectionHelper<T>(items, new string[] { property });
        }
    }

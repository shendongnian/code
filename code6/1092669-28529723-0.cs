	public class ReflectionHelper<T>
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
		
		public static implicit operator IEnumerable<T>(ReflectionHelper<T> helper)
		{
			return helper._list.Select(item => string.Join(",",
							(from p in helper._properties
							select typeof(T).GetProperty(p).GetValue(item, null)).ToArray()));
		}
	}
    public static class ReflectionHelperExtension
    {
        public ReflectionHelper<T> Prop(this IEnumerable<T> items, string property)
        {
            return new ReflectionHelper<T>(items, new string[] { property});
        }
    }

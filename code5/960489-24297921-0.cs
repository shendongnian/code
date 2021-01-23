	public static class Enum<T>
      where T : struct, IComparable, IFormattable, IConvertible
    {
        public static IEnumerable<string> GetNames()
        {
            var type = typeof(T);
            var result = ((T[])Enum.GetValues(typeof(T)))
				.Select(t => new { 
					failName = t.ToString(), 
					fi = type.GetField(t.ToString())
				})
				.Select(a => new {
					faileName = a.failName,
				    displayAttribute =
                      (a.fi.GetCustomAttributes(typeof(DisplayAttribute), false) 
                      as DisplayAttribute[]).FirstOrDefault()
				})
				.Select(a => a.displayAttribute != null 
                             ? a.displayAttribute.Name : a.faileName)
                .ToList();
            return result;
        }

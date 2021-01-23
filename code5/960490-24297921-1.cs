	public static class Enum<T>
      where T : struct, IComparable, IFormattable, IConvertible
    {
        public static IEnumerable<string> GetNames()
        {
            var result = ((T[])Enum.GetValues(typeof(T)))
                .Select(t => new
                {
                    failName = t.ToString(),
                    displayAttribute = (typeof(T)
                        .GetField(t.ToString())
                        .GetCustomAttributes(typeof(DisplayAttribute), false) 
                          as DisplayAttribute[]).FirstOrDefault()
                })
                .Select(a => a.displayAttribute != null 
                  ? a.displayAttribute.Name: a.failName)
                .ToList();
            return result;
        }

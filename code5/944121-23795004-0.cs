    public static class EnumExtensions
        {
            public static List<T> Values<T>(this T theEnum)
                where T : struct,  IComparable, IFormattable, IConvertible
            {
                if (!typeof(T).IsEnum) 
                    throw new InvalidOperationException(string.Format("Type {0} is not enum.", typeof(T).FullName)); 
    
                return Enum.GetValues(theEnum.GetType()).Cast<T>().ToList();
            }
        }

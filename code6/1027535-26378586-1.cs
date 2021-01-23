    public class Expression<T>
    {
        public T Value { get; set; }
        public string ExpressionText { get; set; }
    
        public static Expression<T> Convert(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
    
            if (input.StartsWith("="))
                return new Expression<T> { ExpressionText = input };
    
            var converter = TypeDescriptor.GetConverter(typeof(T));
            T value = (T)converter.ConvertFromString(input);
    
            return new Expression<T> { Value = value };
        }
    
        public static implicit operator Expression<T>(T value)
        {
            if (value == null)
                return null;
    
            var str = value as string;
            if (!string.IsNullOrEmpty(str))
                return Convert(str);
            else
                return new Expression<T> { Value = value };
        }
    }

    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                Expression<string> str = "1";
    
            }
        }
        public class Expression<T>
        {
            public T Value { get; set; }
            public string ExpressionText { get; set; }
    
           
    
            public static implicit operator Expression<T>(T value)
            {
                if (value is string) {
                    string input = value.ToString();
                    if (string.IsNullOrEmpty(input))
                        return null;
    
                    if (input.StartsWith("="))
                        return new Expression<T> { ExpressionText = input };
    
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    T tValu = (T)converter.ConvertFromString(input);
    
                    return new Expression<T> { Value = tValu };
                }
                else if (value == null)
                    return null;
    
                return new Expression<T> { Value = value };
            }
        }
    }

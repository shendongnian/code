    public class StructInputValidator<T> : InputValidator<T?> where T : struct
    {
        public StructInputValidator(TryParse<T> parser, T? initialValue) 
            : base(ToNullableTryParse(parser), initialValue)
        { }
    
        private static TryParse<T?> ToNullableTryParse(TryParse<T> parser)
        {
            return (string text, out T? result) => {
                T nonNullableResult;
                bool parseSuccessful = parser(text, out nonNullableResult);
                result = parseSuccessful ? (T?)nonNullableResult : null;
                return parseSuccessful;
            };
        }
    }

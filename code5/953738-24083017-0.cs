    public static class ValidationExtensions
    {
        public static Validation<T> Validate<T>(this T source)
        {
            return new Validation<T>(source);
        }
    }
    public class Validation<T>
    {
        private readonly T valueToValidate;
        public Validation(T value)
        {
            valueToValidate = value;
        }
        public void Is<T>(T value)
        {
            if (!Object.Equals(valueToValidate, value))
                throw new Exception();
        }
    }
    string s = "Hello World";
    s.Validate().Is("Hello World");
   

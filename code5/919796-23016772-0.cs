    public class MyClass<T> where T: TClass
    {
        public void GetValueFromType(T value)
        {
            Console.WriteLine("Genric method called");
            value.MyTypeMethod();
        }
    }

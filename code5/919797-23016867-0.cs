    public class MyClass<T> where T : MyBase
    {
        public void GetValueFromType()
        {
            T.MyTypeMethod();        
            Console.WriteLine("Generic method called");
    
        }
    }

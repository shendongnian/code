    public class MyClass
    {
        public void StdException(Exception ex)
        {
            Console.WriteLine("Thrown");
        }
    
        public void Do()
        {
            this.StdTryCatch(() =>
                             {
                                 throw new Exception();
                             });
        }
    }
 

    public class MyValidator : IValidator
    {
        public bool IsValid(string data)
        {
            //code which returns bool
        }
        
        public static readonly IValidator Instance = new MyValidator();
    }

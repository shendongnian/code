    public class MyValidator : IValidator
    {
        public bool IsValid(strig data)
        {
            //code which returns bool
        }
        
        public static readonly IValidator Instance = new MyValidator();
    }

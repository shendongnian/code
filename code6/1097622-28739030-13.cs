    public class MyClass1 : IValidationRule
    {
        public bool IsValid()
        {
            Debug.WriteLine("Valid 1");
    		return true;
        }
    }
    public class MyClass2 : IValidationRule
    {
        public bool IsValid()
        {
            Debug.WriteLine("Valid 2");
    		return false;
        }
    }

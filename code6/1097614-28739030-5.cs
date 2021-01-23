    public class MyClass1 : IValidationRule
    {
        public bool IsValid()
        {
            Debug.WriteLine("Valide 1");
    		return true;
        }
    }
    public class MyClass2 : IValidationRule
    {
        public bool IsValid()
        {
            Debug.WriteLine("Valide 2");
    		return false;
        }
    }

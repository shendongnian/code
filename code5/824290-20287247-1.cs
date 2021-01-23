    public class SomeClass
    {
        public string SomeProperty
        {
            get
            {
                string s = StackHelper.GetCurrentPropertyName();
                return /* ... */;
            }
        }
    }

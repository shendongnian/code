    public class SomeViewModel
    {
        private readonly MyClass myClass;
        public SomeViewModel(IMyClassFactory myClassFactory) 
        {
            myClass = myClassFactory.Create("MyParameter");
        }
    }

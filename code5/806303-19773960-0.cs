    public class MyClass : IMyClass
    {
        public MyClass(ISomeClass someClass)
        {
            someClass.SetupStuff();
        }
        public void IMyClass.Direct()
        {
           // want to test this
        }
    }

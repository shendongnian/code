    public class ConcreteDependency : IDependency
    {
        public void DoThing()
        {
            //Implementation here
        }
    }
    
    public class MyClassThatUsesTheLibrary()
    {
        public void MyMethod()
        {
            var dependency = new ConcreteDependency();
            var libraryClass = new MyLibraryClass(dependency);
            libraryClass.MyUsefulMethod();
        }
    }

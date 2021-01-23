    public interface IDependency
    {
        void DoThing();
    }
    
    public class MyLibraryClass
    {
        IDependency _dependency;
    
        public MyLibraryClass(IDependency dependency)
        {
            _dependency = dependency;
        }
    
        public void MyUsefulMethod()
        {
            //Some stuff
            _dependency.DoThing();
            //Some more stuff
        }
    }

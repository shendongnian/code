    public class NoNotReally {
        private IMyDependency1 _myDependency;
        public IMyDependency1 MyDependency {get {return _myDependency;}}
    
        public NoNotReally(IMyDependency dependency) {
            _myDependency = null; // instead of dependency. Really?
        }
    }

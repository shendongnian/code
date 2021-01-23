    public class Wrapper<T>() {
        public WrapperObsCollection(ObservableCollection<T> collection) {
          IsReadOnly      = false;
          ObsCollection   = collection;
          ROObsCollection = null;
        }
        public WrapperObsCollection(ReadOnlyObservableCollection<T> collection : base {
          IsReadOnly      = true;
          ObsCollection   = null;
          ROObsCollection = collection;
        }
    
        public bool                            IsReadOnly        { get; private set; }
        public ObservableCollection<T>         ObsCollection     { get; private set; }
        public ReadOnlyObsrevableCollection<T> ROObsCollection   { get; private set; }
    }

    public class Model
    {
        private readonly ObservableCollection<Thing> _allThings = new ObservableCollection<Thing>();
        public IEnumerable<Thing> AllThings { get { return _allThings; }}
     }

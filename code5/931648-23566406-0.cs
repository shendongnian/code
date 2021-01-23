    public static class HelperFoo
    {
        private static Dictionary<ObservableCollection<Bar>, object> lookupCreators = new Dictionary<ObservableCollection<Bar>, object>();
        public static void AddBarsCreator(ObservableCollection<Bar> bars, object creator)
        {
            lookupCreators.Add(bars, creator);
        }
        public static void Bars_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<Bar> bars = (ObservableCollection<Bar>)sender;
            if (lookupCreators.ContainsKey(bars))
            {
            }
        }
    }
    public class Foo
    {
        public ObservableCollection<Bar> Bars { get; set; }
        public Foo()
        {
            Bars = new ObservableCollection<Bar>();
            HelperFoo.AddBarsCreator(Bars, this);
            Bars.CollectionChanged += HelperFoo.Bars_CollectionChanged;
        }
    }

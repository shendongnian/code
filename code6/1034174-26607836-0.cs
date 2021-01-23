    internal class Foo
    {
        // The list which can be manipulated only be Foo itself.
        private List<Bar> _Bars;
        // The proxy that will be given out to the consumers.
        private ReadOnlyCollection<Bar> _BarsReadOnly;
        public Foo()
        {
           // Create the mutable list.
            _Bars = new List<Bar>();
           // This is a wrapper class that holds a
           // reference to the mutable class, but
           // throws an exception to all change methods. 
            _BarsReadOnly = _Bars.AsReadOnly();
        }
        public IReadOnlyList<Bar> Bars
        {
            // Simply give out the wrapper.
            get { return _BarsReadOnly; }
        }
        public void AddBar(Vector dimensions)
        {
            // Manipulate the only intern available
            // changeable list...
            _Bars.Add(new Bar(dimensions));
        }
        public void SortBars()
        {
           // To change the order of the list itself
           // call the Sort() method of list with
           // a comparer that is able to sort the list
           // as you like.
            _Bars.Sort(BarComparer.Default);
           // The method OrderBy() won't have any
           // immediate effect.
           var orderedList = _Bars.OrderBy(i => i.Volume);
           // That's because it will just create an enumerable
           // which will iterate over your given list in
           // the desired order, but it won't change the
           // list itself and so also not the outgiven wrappers!
        }
    }

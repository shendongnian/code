    public class Catalog<T> where T: BaseItem
    {
        public delegate void GenericListItemCountChangedEvent<T>(object sender, GenericListItemCountChangedEventArgs<T> e) where T : BaseItem;
        //This is the point where it does not work, because I specify BaseItem as the type
        public event EventHandler<GenericListItemCountChangedEventArgs<T>> GenericListItemCountChanged;
        private void RaiseGenericListItemCountChangedEvent(List<T> List)
        {
            if (GenericListItemCountChanged != null)
            {
                GenericListItemCountChanged(this, new GenericListItemCountChangedEventArgs<T>(List));
            }
        }
        public class GenericListItemCountChangedEventArgs<T> : EventArgs where T : BaseItem
        {
            private List<T> _changedList_propStore;
            public List<T> ChangedList
            {
                get
                {
                    return _changedList_propStore;
                }
            }
            public GenericListItemCountChangedEventArgs(List<T> ChangedList)
            {
                _changedList_propStore = ChangedList;
            }
        }
    }
    public  class MainWindow 
    {
        public MainWindow()
        {
            new Catalog<BaseItem>().GenericListItemCountChanged += (sender, e) => GenericListItemCountChanged(sender, e);
        }
        private void GenericListItemCountChanged<T>(object sender, Catalog<BaseItem>.GenericListItemCountChangedEventArgs<T> e) where T : BaseItem
        {
            //Use Generic EventArgs
        }
    }

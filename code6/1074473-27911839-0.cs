    interface IBaseItemEventArgs<out T>
    {
        IReadOnlyList<T> ChangedList { get; }
    }
    class GenericListItemCountChangedEventArgs<T> : EventArgs, IBaseItemEventArgs<T>
        where T : BaseItem
    {
        private IReadOnlyList<T> _changedList_propStore;
        public IReadOnlyList<T> ChangedList
        {
            get
            {
                return _changedList_propStore;
            }
        }
        public GenericListItemCountChangedEventArgs(List<T> ChangedList)
        {
            _changedList_propStore = ChangedList.AsReadOnly();
        }
    }
    public delegate void
        GenericListItemCountChangedEvent<in T>(object sender, IBaseItemEventArgs<T> e)
        where T : BaseItem;
    public static event
        GenericListItemCountChangedEvent<BaseItem> GenericListItemCountChanged;
    private static void RaiseGenericListItemCountChangedEvent<T>(List<T> List)
        where T : BaseItem
    {
        GenericListItemCountChangedEvent<T> handler = GenericListItemCountChanged;
        if (handler != null)
        {
            handler(null, new GenericListItemCountChangedEventArgs<T>(List));
        }
    }

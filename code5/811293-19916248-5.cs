    public class HierarchicalObservableCollection<TParent, TItems> : ObservableCollection<TItems>
    {
        public TParent Parent { get; protected set; }
        public Action<TItems, TParent> ItemParentSetter { get; protected set; }
        public HierarchicalObservableCollection(TParent parent, Action<TItems, TParent> parentSetter)
        {
            Parent = parent;
            ItemParentSetter = parentSetter;
        }
        public new void Add(TItems item)
        {
            if (item != null)
                ItemParentSetter(item, Parent);
            base.Add(item);
        }
    }

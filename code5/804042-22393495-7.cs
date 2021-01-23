    public class GroupedCollection<T, TGroup> : ObservableCollection<object>
    {
        private Func<T, TGroup> _grouping;
        public IEnumerable<T> BaseItems
        {
            get { return base.Items.OfType<T>(); }
        }
        public GroupedCollection(IEnumerable<T> initial, Func<T, TGroup> grouping)
            : base(GetGroupedItems(initial, grouping))
        {
            _grouping = grouping;
        }
        private static IEnumerable<object> GetGroupedItems(IEnumerable<T> items, Func<T, TGroup> grouping)
        {
            return items
                .GroupBy(grouping)
                .SelectMany(grp => 
                    new object[] { new ComboBoxGroupHeader(grp.Key) } 
                        .Union(grp.OfType<object>())
                );
        }
    }

    public class SortedObservableCollection<T> : ObservableCollection<T> where T : IComparable<T>
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
            if (e.Action != NotifyCollectionChangedAction.Reset && e.Action != NotifyCollectionChangedAction.Move)
            {
                var query = this.Select((item, index) => (Item: item, Index: index)).OrderBy(tuple => tuple.Item, Comparer.Default);
                var map = query.Select((tuple, index) => (OldIndex: tuple.Index, NewIndex: index)).Where(o => o.OldIndex != o.NewIndex);
                using (var enumerator = map.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        base.MoveItem(enumerator.Current.OldIndex, enumerator.Current.NewIndex);
                    }
                }
            }
        }
        // (optional) user is not allowed to move items in a sorted collection
        protected override void MoveItem(int oldIndex, int newIndex) => throw new InvalidOperationException();
        protected override void SetItem(int index, T item) => throw new InvalidOperationException();
        private class Comparer : IComparer<T>
        {
            public static readonly Comparer Default = new Comparer();
            public int Compare(T x, T y) => x.CompareTo(y);
        }
    }

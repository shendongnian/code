    public class MyList<T> : ObservableCollection<T>
    {
        public void AddRange(IEnumerable<T> items)
        {
            this.AddRange(items);
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items.ToList(), null);
            base.OnCollectionChanged(args);
        }
        public void RemoveRange(Func<T, bool> predicate)
        { RemoveRange(this.Where(predicate)); }
        private void RemoveRange(IEnumerable<T> items)
        {
            this.RemoveRange(items);
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, null, items.ToList());
            base.OnCollectionChanged(args);
        }
    }

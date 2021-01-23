    public class customListView : ListView
    {
        public event EventHandler<CustomEventArgs> UpdateListViewCounts;
        public void UpdateList(string data)
        {
            // You may have to modify this depending on the
            // Complexity of your Items
            this.Items.Add(new ListViewItem(data));
            CustomEventArgs e = new CustomEventArgs(Items.Count);
            UpdateListViewCounts(this, e);
        }
    }
    public class CustomEventArgs : EventArgs
    {
        private int _count;
        public CustomEventArgs(int count)
        {
            _count = count;
        }
        public int Count
        {
            get { return _count; }
        }
    }

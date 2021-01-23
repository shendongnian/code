    public class ViewModel
    {
        public ViewModel()
        {
            foreach (var item in Enumerable.Range(1, 50))
                this.Items.Add(item);
        }
        ObservableCollection<int> _Items = new ObservableCollection<int>();
        public ObservableCollection<int> Items { get { return _Items; } }
    }

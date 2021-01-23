    public class ViewModel
    {
        public ViewModel()
        {
            Items = new ObservableCollection<DataItem>(RandomDataSource.GetRandomData());
            Filters = new ObservableCollection<DataFilter>();
            Filters.Add(new DataFilter()
            {
                DisplayName = "First Name starting with A",
                FilterExpression = x => x.FirstName.ToLower().StartsWith("a")
            });
            Filters.Add(new DataFilter()
            {
                DisplayName = "Last Name starting with E",
                FilterExpression = x => x.LastName.ToLower().StartsWith("e")
            });
        }
        public ObservableCollection<DataItem> Items { get; private set; }
        public DataFilter SelectedFilter { get; set; }
        public ObservableCollection<DataFilter> Filters { get; private set; }
        public void Filter()
        {
            if (SelectedFilter == null)
                return;
            foreach (var item in Items)
                item.IsSelected = SelectedFilter.FilterExpression(item);
        }
    }

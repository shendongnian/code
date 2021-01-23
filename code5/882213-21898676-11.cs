    public class ViewModel
    {
        public List<string> RowMarkers { get; set; }
        public List<string> ColumnMarkers { get; set; }
        public ObservableCollection<Item> Items { get; set; }
        public ViewModel()
        {
            RowMarkers = Enumerable.Range(1, 50).Select(x => x.ToString()).ToList();
            ColumnMarkers = new[] { " " }.Concat(Enumerable.Range(1, 50).Select(x => x.ToString())).ToList();
            
            var list = new List<Item>();
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    list.Add(new Item());
                }
            }
            Items = new ObservableCollection<Item>(list);
        }
    }

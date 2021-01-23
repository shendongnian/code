    public class RowViewModel
    {
        public string SellingPrice { get; set; }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            Rows = new ObservableCollection<RowViewModel>
            {
                  new RowViewModel { SellingPrice = "123" },
                  new RowViewModel { SellingPrice = "456" }, 
            };
        }
        public IEnumerable<RowViewModel> Rows { get; set; }
    }

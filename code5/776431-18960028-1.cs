    public class myViewModel
    {
        public myViewModel()
        {
            SelectedItemChangedCommand = new DelegateCommand<object>((selectedItem) => 
            {
                 // Logic goes here
            });
        }
        public List<SomeData> SomeCollection { get; set; }
        public DelegateCommand<object> SelectedItemChangedCommand { get; set; }
    }

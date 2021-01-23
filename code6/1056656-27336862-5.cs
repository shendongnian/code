    using System.Collections.ObjectModel;
    public class MockItemViewModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
    }
    public class MockMasterViewModel
    {
        public ObservableCollection<MockItemViewModel> Items { get; set; }
        public MockMasterViewModel()
        {
            var item01 = new MockItemViewModel() { Title = "Title 01", Address = "Address 01" };
            var item02 = new MockItemViewModel() { Title = "Title 02", Address = "Address 02" };
            Items = new ObservableCollection<MockItemViewModel>()
            {
                item01, item02
            };
        }
    }

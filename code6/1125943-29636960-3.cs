    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Action<MyItem> action = item => Console.WriteLine(@"MyItem was clicked");
            CollectionFooViewModel = new ObservableCollection<MyItem>()
            {
                new MyItem()
                {
                    Name = "MyItem1",
                    Children = new List<MyItem>()
                    { 
                        new MyItem()
                        {
                            Name = "MySubItem1", 
                            IsChecked = false, 
                            Action = item => Console.WriteLine(@"{0} invoked action", item.Name)
                        },
                        new MyItem()
                        {
                            Name = "MySubItem2", 
                            IsChecked = true, 
                            Action = item => Console.WriteLine(@"{0} state is {1} ", item.Name, item.IsChecked)
                        },
                    },
                    Action = action
                }
            };
        }
        public ObservableCollection<MyItem> CollectionFooViewModel { get; set; }
    }
    public class MyItem : ViewModelBase
    {
        private bool _isChecked;
        public string Name { get; set; }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                if (Action != null)
                    Action.BeginInvoke(this, null, null);
            }
        }
        public IEnumerable<MyItem> Children { get; set; }
        public Action<MyItem> Action { get; set; }
    }

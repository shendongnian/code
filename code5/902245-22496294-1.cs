    class MyViewModel : INotifyPropertyChanged
    {
        public MyViewModel()
        {
            First = new ItemListViewModel<string>();
            Second = new ItemListViewModel<string>();
            Third = new ItemListViewModel<string>();
    
            First.PropertyChanged += (s, e) => Update(e.PropertyName, First, Second, LoadSecond);
            Second.PropertyChanged += (s, e) => Update(e.PropertyName, Second, Third, LoadThird);
    
            LoadFirst();
        }
    
        public ItemListViewModel<string> First { get; set; }
        public ItemListViewModel<string> Second { get; set; }
        public ItemListViewModel<string> Third { get; set; }
    
        private void LoadFirst()
        {
            First.SetItems(new List<string> { "One", "Two", "Three" });
        }
        private void LoadSecond()
        {
            Second.SetItems(new List<string> { "First", "Second", "Third" });
        }
        private void LoadThird()
        {
             Third.SetItems(new List<string> { "Firsty", "Secondly", "Thirdly" });
        }
    
        private void Update<T0, T1>(string propertyName, ItemListViewModel<T0> parent, ItemListViewModel<T1> child, Action loadAction)
            where T0 : class
            where T1 : class
        {
            if (propertyName == "SelectedItem")
            {
                if (parent.SelectedItem == null)
                {
                    child.SetItems(Enumerable.Empty<T1>());
                }
                else
                {
                    loadAction();
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }

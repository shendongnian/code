    namespace WpfApplication1
    {
        public class MainViewModel : INotifyPropertyChanged
        {
            #region Members
            private ItemType _selectedType;
            private List<Item> _allItems;
            private List<Item> _items;
            #endregion Members
    
            #region Properties
            /// <summary>
            /// Gets or sets the Selected Item Type
            /// </summary>
            /// <value>
            /// The selected Item Type
            /// </value>
            public ItemType SelectedType
            {
                get { return _selectedType; }
                set
                {
                    _selectedType = value;
                    Filter(); // Filter items list once SelectedType has changed
                }
            }
    
            /// <summary>
            /// Gets a list of all Item Types
            /// </summary>
            public List<ItemType> Types { get; private set; }
    
            /// <summary>
            /// Gets or sets the currently filltered list of Items
            /// </summary>
            /// <value>
            /// The fitlered items.
            /// </value>
            public List<Item> Items 
            {
                get { return _items; }
                set
                {
                    _items = value;
                    NotifyPropertyChanged("Items");
                }
            }
            #endregion Properties
    
            public MainViewModel()
            {
                Types = new List<ItemType>
                {
                    ItemType.All,
                    ItemType.Fruit,
                    ItemType.Car
                };
    
                _allItems = new List<Item>
                {
                    new Item
                    {
                        Value = "Apple",
                        Type = ItemType.Fruit
                    },
                    new Item
                    {
                        Value = "Orange",
                        Type = ItemType.Fruit
                    },
                    new Item
                    {
                        Value = "Honda",
                        Type = ItemType.Car
                    },
                    new Item
                    {
                        Value = "Nissan",
                        Type = ItemType.Car
                    }
                };
                Items = _allItems;
            }
    
            /// <summary>
            /// Filters the Items list based on currently selected Item Type
            /// </summary>
            private void Filter()
            {
                 var filteredItems = new List<Item>();
                 if (ItemType.All == _selectedType)
                 {
                     filteredItems = _allItems;
                 }
                 else 
                 {
                     foreach (var item in _allItems)
                     {
                         if (item.Type == _selectedType)
                         {
                             filteredItems.Add(item);
                         }
                     }
                 }
                 Items = filteredItems;
            }
    
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            #endregion
        }
    
        public enum ItemType
        {
            All,
            Fruit,
            Car
        }
    
        public class Item
        {
            public string Value { get; set; }
            public ItemType Type { get; set; }
        }
    }

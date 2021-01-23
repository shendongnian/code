    public class MyViewModel : INotifyPropertyChanged
    {
        // backing fields, etc...
        public List<DerivedClass> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }
        public int Sum
        {
            get
            {
                return this.Items != null ? this.Items.Sum(i => i.X + i.Y) : 0;
            }
        }
       ...       
       public void PopulateItems()
       {
           this.Items = MyMethodToGetItems();
           foreach (var item in this.Items)
           {
               item.PropertyChanged += this.ItemPropertyChanged;
           }
       }
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "X" || propertyChangedEventArgs.PropertyName == "Y")
            {
                OnPropertyChanged("Sum");
            }
        }
    }

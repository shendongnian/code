    public class Fields : ObservableCollection<Field>
    {
        protected override event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        void FieldPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                NotifyPropertyChanged("SelectedItemsCount"); 
            }
        }
        protected override void InsertItem(int index, Field item)
        {
    	if (item != null)
                item.PropertyChanged -= FieldPropertyChanged;
  
            base.InsertItem(index, item);
            if (item != null)
                item.PropertyChanged += FieldPropertyChanged;
        }
        protected override void ClearItems()
        {
            foreach (Field field in this)
            {
                field.PropertyChanged -= FieldPropertyChanged;
            }
            base.ClearItems();
        }
        protected override void RemoveItem(int index)
        {
            if (this[index] != null)
                this[index].PropertyChanged -= FieldPropertyChanged;
            base.RemoveItem(index);
        }
        private int selectedItemsCount;
        public int SelectedItemsCount
        {
            //This can be more efficient, not have to count everytime
            get
            {
                selectedItemsCount = 0;
                foreach (Field field in this)
                {
                    if (field.IsSelected)
                        selectedItemsCount++;
                }
                return selectedItemsCount;
            }
        }
    }

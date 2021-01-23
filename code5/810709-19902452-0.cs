    public class NotificationClass : INotifyPropertyChanged
    {
        private TabDataItem selectedItem;
    
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    
         /// <summary>
        ///     Gets or sets the SelectedTabItem.
        /// </summary>
        public TabDataItem SelectedTabItem
        {
            get
            {
                return this.selectedItem;
            }
            internal set
            {
                if (this.selectedItem != value)
                {
                    this.selectedItem = value;
                    OnPropertyChanged("SelectedTabItem");
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Location SelectedcbDefaultLocationListItem = new Location { LocationName = "---Select One---", LocationID = -1 };
        public ObservableCollection<Location> LocationList { get; set; }
        private int _selectedLocationID;
        /// <summary>
        /// Get/Set the SelectedLocationID property. Raises property changed event.
        /// </summary>
        public int SelectedLocationID
        {
            get { return _selectedLocationID; }
            set
            {
                if (_selectedLocationID != value)
                {
                    _selectedLocationID = value;
                    RaisePropertyChanged("SelectedLocationID");
                }
            }
        }        
        /// <summary>
        /// Constructor
        /// </summary>
        public MyViewModel()
        {
            LocationList = new ObservableCollection<Location>();
            LocationList.Add(new Location() { LocationID = 1, LocationName = "Here" });
            LocationList.Add(new Location() { LocationID = 2, LocationName = "There" });
            LocationList.Insert(0, SelectedcbDefaultLocationListItem);
            SelectedLocationID = SelectedcbDefaultLocationListItem.LocationID;
        }
        /// <summary>
        /// Resets the selection to the default item.
        /// </summary>
        public void ResetSelectedItem()
        {
            SelectedLocationID = SelectedcbDefaultLocationListItem.LocationID;
        }
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }   
    }

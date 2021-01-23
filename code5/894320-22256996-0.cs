    [Serializable]
    public class UserPreferences : INotifyPropertyChanged
    {
        private CollectionDevice selectedCollectionDevice;
        public UserPreferences()
        {
            this.AvailableCollectionDevices = new List<CollectionDevice>();
            
            var yuma1 = new CollectionDevice
            {
                BaudRate = 4800,
                ComPort = 31,
                DataPoints = 1,
                Name = "Trimble Yuma 1",
                WAAS = true
            };
            var yuma2 = new CollectionDevice
            {
                BaudRate = 4800,
                ComPort = 3,
                DataPoints = 1,
                Name = "Trimble Yuma 2",
                WAAS = true
            };
            var toughbook = new CollectionDevice
            {
                BaudRate = 4800,
                ComPort = 3,
                DataPoints = 1,
                Name = "Panasonic Toughbook",
                WAAS = true
            };
            
            var other = new CollectionDevice
            {
                BaudRate = 0,
                ComPort = 0,
                DataPoints = 0,
                Name = "Other",
                WAAS = false
            };
            
            this.AvailableCollectionDevices.Add(yuma1);
            this.AvailableCollectionDevices.Add(yuma2);
            this.AvailableCollectionDevices.Add(toughbook);
            this.AvailableCollectionDevices.Add(other);
            this.SelectedCollectionDevice = this.AvailableCollectionDevices.First();
        }
        /// <summary>
        /// Gets or sets the GPS collection device.
        /// </summary>
        public CollectionDevice SelectedCollectionDevice
        {
            get
            {
                return selectedCollectionDevice;
            }
            set
            {
                selectedCollectionDevice = value;
                if (selectedCollectionDevice.Name == "Other")
                {
                    this.AvailableCollectionDevices[3] = value;
                }
                this.OnPropertyChanged("SelectedCollectionDevice");
            }
        }
        /// <summary>
        /// Gets or sets a collection of devices that can be used for collecting GPS data.
        /// </summary>
        [Ignore]
        [XmlIgnore]
        public List<CollectionDevice> AvailableCollectionDevices { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies objects registered to receive this event that a property value has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that was changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

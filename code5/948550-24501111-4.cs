    public YourModel : INotifyPropertyChanged
    {
        public YourModel()
        {
            // Contructor code...
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged Members
        public void SaveSettings()
        {
            // code to copy this._defaultSettings to Scanning.Properties.Settings.Default
            Scanning.Properties.Settings.Default.profile1_papersize = this._defaultSettings.profile1_papersize;
            Scanning.Properties.Settings.Default.OtherProperty1 = this._defaultSettings.Property1;
            Scanning.Properties.Settings.Default.OtherProperty2 = this._defaultSettings.Property2;
            Scanning.Properties.Settings.Default.OtherProperty3 = this._defaultSettings.Property3;
            // code to save Scanning.Properties.Settings.Default
        }
        private YourSettingsType _defaultSettings;
        public YourSettingsType DefaultSettings
        { 
            get 
            { 
                if (this._defaultSettings == null) this.DefaultSettings = Scanning.Properties.Settings.Default; 
                return this._defaultSettings;
            }
            set 
            { 
                this._defaultSettings = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs("DefaultSettings"));
            }
        }
    }

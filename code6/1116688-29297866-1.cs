     public sealed class SettingsService : INotifyPropertyChanged
        {
            private static Lazy<SettingsService> instance = new Lazy<SettingsService>(() => new SettingsService());
            public static SettingsService Instance
            {
                get { return instance.Value; }
            }
            private Setting settings;
            public Setting Settings
            {
               get
               {
                  var clone = settings.Clone();
                  return clone;
               }
            }
            
            private SettingsService()
            {
               //load your settings
            }            
            public void SaveChanges(Setting settings)
            {
               //Do whatever you do to save the changes, and raise the event the   settings changed
               this.settings = settings;
               NotifyPropertyChanged();
            }
            private void NotifyPropertyChanged()
            {
                if (PropertyChanged != null)
                   PropertyChanged(this, new PropertyChangedEventArgs("Settings"));
            }
            public event PropertyChangedEventHandler PropertyChanged;
    }

    public class NavigatorViewModel : INotifyPropertyChanged
    {
        public NavigatorViewModel()
        {
            // Respond to the Singlton PropertyChanged events
            ViewModelLocator.DesktopStatic.PropertyChanged += OnDesktopStaticPropertyChanged;
        }
        private void OnDesktopStaticPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            // Check which property changed
            if (args.PropertyName == "CurrentProject")
            {
                // Assuming NavigatorViewModel also has this method
                RaisePropertyChanged("CurrentProject");
            }
        }
    }

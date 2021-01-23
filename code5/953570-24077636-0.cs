     public class PathSelectionPageViewModel : ObservableObject, INavigable, INotifyPropertyChanged
    {
        private DriveInfo driveSelection;
        public DriveInfo DriveSelection_SelectionChanged
        {
            get
            {
                return driveSelection;
            }
            set
            {
    
                if (value == driveSelection) return;
                driveSelection = value;
                NotifyOfPropertyChange("DriveSelection_SelectionChanged");
            }
    
        }
    
         public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    }

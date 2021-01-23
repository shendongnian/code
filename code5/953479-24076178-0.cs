       <ComboBox Height="23" 
            Name="DriveSelection" Width="120"
            ItemsSource="{Binding Path=FixedDrives}"
            DisplayMemberPath="PropertyOfDriveInfo"
            SelectedItem="{Binding Path=SelectedInfo}" />
    class ViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<DriveInfo> fixedDrives;
        public ObservableCollection<DriveInfo> FixedDrives
        {
            get
            {
                if(fixedDrives==null)
                {
                   var query =
                    from driveInfo in DriveInfo.GetDrives()
                    //where driveInfo.DriveType == DriveType.Fixed
                    select driveInfo;
                   fixedDrives= new ObservableCollection<DriveInfo>(query);
                   return fixedDrives;
                }
                return fixedDrives;
             }
        }
    
        private DriveInfo _selectedInfo
        public DriveInfo SelectedInfo
        {
            get { return _electedInfo; }
            set
            {
                if (value == _electedInfo) return;
                _selectedInfo= value;
                NotifyOfPropertyChange(() => SelectedInfo);//must be implemented
            }
        }
    }
    

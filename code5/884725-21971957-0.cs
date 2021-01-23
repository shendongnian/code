    public class RibbonTabData : BaseDataType
    {
        private string name = string.Empty;
        private ObservableCollection<RibbonGroupData> ribbonGroupData = new ObservableCollection<RibbonGroupData>();
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        public ObservableCollection<RibbonGroupData> RibbonGroupData
        {
            get { return ribbonGroupData; }
            set { ribbonGroupData = value; NotifyPropertyChanged("RibbonGroupData"); }
        }
    }
    public class RibbonGroupData : BaseDataType
    {
        private string name = string.Empty;
        private ObservableCollection<RibbonButtonData> ribbonButtonData = new ObservableCollection<RibbonButtonData>();
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        public ObservableCollection<RibbonButtonData> RibbonButtonData
        {
            get { return ribbonButtonData; }
            set { ribbonButtonData = value; NotifyPropertyChanged("RibbonButtonData"); }
        }
    }
    public class RibbonButtonData : BaseDataType
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
    }

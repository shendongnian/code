    public class ThirdPartyUpdate
    {
        public string AppIcon { get; set; }
        public string AppName { get; set; }
        public string AppVersion { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<ThirdPartyUpdate> ThirdPartyUpdates { get; set; }
    }

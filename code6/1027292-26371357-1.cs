    public class BuildingManagementSystem:INotifyPropertyChanged
    {
     private string _Name;
     public string Name { 
     get {return _Name;}
     set {
          if (_Name!= value)
                {
                    _Name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
     }
    public FireAlarmSystem FireAlarmSystem { get; set; }
    public BuildingManagementSystem()
    {          
        FireAlarmSystem = new FireAlarmSystem();         
    }
      #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
      }
    }
    class FireAlarmSystem:INotifyPropertyChanged
    {
        private int alarmSmokeRate, currentSmokeRate;
        public  ObservableCollection<PowerConsumer> Devices { get; set; }
        public int CurrentSmokeRate
        {
            get { return currentSmokeRate; }
            set {
 
                SetField(ref currentSmokeRate, value, () => CurrentSmokeRate); 
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentSmokeRate"));
            }
        }
        public FireAlarmSystem()
        {
            Devices = new ObservableCollection<PowerConsumer>();
        }
      #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
}

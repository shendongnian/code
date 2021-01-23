    public SensorData LastItem
    {
        get { return SensorDataCollection.Last(); }
    }
    public ObservableCollection<SensorData> SensorDataCollection
    {
        get { return sensorDataCollection; }
        set
        {
            sensorDataCollection = value;
            NotifyPropertyChanged("SensorDataCollection"); // <-- INotifyPropertyChanged
            NotifyPropertyChanged("LastItem"); // <-- Notify LastItem change here too
        }
    }
        
...
    <TextBlock Text="{Binding LastItem}" />

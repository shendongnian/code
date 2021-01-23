    public class MainWindowViewModel : ViewModelBase
    {
        public  SensorDTO RootSensor { get; set; }
        public async Task InitializeAsync()
        {
            var storage = await Storage.GetInstanceAsync()
            RootSensor.Data.GetItem<SensorDTO>(t=>t.Parent==t);
        }
    }

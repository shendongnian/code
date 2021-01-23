    <DataGrid Name="FireAlarmGrid" HorizontalAlignment="Left" Margin="10,51,0,0" CanUserAddRows="True" 
                              CanUserDeleteRows="True" VerticalAlignment="Top" AutoGenerateColumns="False" ItemsSource="{Binding  FireAlarmSystem.Devices}"  >
            <DataGrid.RowValidationRules>
                <local:FireValidationRule ValidationStep="UpdatedValue"/>
            </DataGrid.RowValidationRules>
            <DataGrid.Columns>
                <DataGridCheckBoxColumn Header="Enabled" Binding="{Binding Enabled,Mode=TwoWay}"></DataGridCheckBoxColumn>
                <DataGridTextColumn Header="Name" Binding="{Binding Name,ValidatesOnExceptions=True,Mode=TwoWay }"  >
                </DataGridTextColumn>
                <DataGridTextColumn Header="Power" Binding="{Binding Power,Mode=TwoWay}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
        <TextBox Name="tbCurrentSmokeRate"   Text="{Binding Path=FireAlarmSystem.CurrentSmokeRate, Mode=TwoWay}" VerticalAlignment="Top" Width="70"/>
    public class BuildingManagementSystem : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        private FireAlarmSystem _fireAlarmSystem;
        public FireAlarmSystem FireAlarmSystem { get { return _fireAlarmSystem; } }
        public BuildingManagementSystem()
        {
            _fireAlarmSystem = new FireAlarmSystem();
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }
    public class FireAlarmSystem : INotifyPropertyChanged
    {
        private int alarmSmokeRate, currentSmokeRate;
        public ObservableCollection<PowerConsumer> Devices { get; set; }
        public int CurrentSmokeRate
        {
            get { return currentSmokeRate; }
            set
            {
                //SetField(ref currentSmokeRate, value, () => CurrentSmokeRate);
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentSmokeRate"));
            }
        }
        public FireAlarmSystem()
        {
            Devices = new ObservableCollection<PowerConsumer>();
            //Create some test data...
            Devices.Add(new PowerConsumer() { Name = "One", Enabled = true, Power = 100, Priority = 1 });
            Devices.Add(new PowerConsumer() { Name = "two", Enabled = false, Power = 101, Priority = 2 });
            Devices.Add(new PowerConsumer() { Name = "three", Enabled = false, Power = 103, Priority = 3 });
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }
    
    public class PowerConsumer
    {
        public string Name { get; set; }
        public double Power { get; set; }
        public int Priority { get; set; }
        public bool Enabled { get; set; }
    }

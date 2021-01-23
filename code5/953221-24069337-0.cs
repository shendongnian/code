    XAML:
    <TextBox Width="120" Canvas.Left="132" Canvas.Top="16" Text="{Binding Path=Server,Mode=TwoWay}"/>
    <TextBox Width="120" Canvas.Left="132" Canvas.Top="42" Text="{Binding Path=DisplayPort,Mode=TwoWay}"/>
    <TextBox Width="120" Canvas.Left="132" Canvas.Top="69" Text="{Binding Path=CtrlPort,Mode=TwoWay}"/>
    <Button Content="Launch" Name="btnLaunch" Command="{Binding Path=appSetting}" Canvas.Left="132" Canvas.Top="100" Width="120" Height="51" Click="btnLaunch_Click" />
    VIEWMODE:
    public class SettingsViewModel : ViewModelBase
    {
        private Settings _settings { get; set; }
        public SettingsViewModel()
        {
            appSetting = new RelayCommand(this.AppSettingsCommand);
            _settings = ApplicationTest.Properties.Settings.Default;
        }
        private string _server = Settings.Default.Server;
        public string Server
        {
            get { return this._server; }
            set
            {
                if (this._server != value)
                {
                    this._server = value;
                    OnPropertyChanged("Server");
                }
            }
        }
        private string _displayPort = Settings.Default.DisplayPort;
        public string DisplayPort
        {
            get { return this._displayPort; }
            set
            {
                if (this._displayPort != value)
                {
                    this._displayPort = value;
                    OnPropertyChanged("DisplayPort");
                }
            }
        }
        private string _ctrlPort = Settings.Default.CtrlPort;
        public string CtrlPort
        {
            get { return this._ctrlPort; }
            set
            {
                if (this._ctrlPort != value)
                {
                    this._ctrlPort = value;
                    OnPropertyChanged("DisplayPort");
                }
            }
        }
        public RelayCommand appSetting
        {
            get;
            set;
        }
        private void AppSettingsCommand()
        {
            this._settings.Server = this.Server;
            this._settings.DisplayPort = this.DisplayPort;
            this._settings.CtrlPort = this.CtrlPort;
            this._settings.Save();
        }

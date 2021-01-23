    public partial class Device_Options : Form
    {
        readonly Devices devices;
        public string deviceSettings;
        public Device_Options(Devices host)
        {
            InitializeComponent();      
            this.devices = host;
            deviceLabel.Text = devices.selectedDevice;
        }

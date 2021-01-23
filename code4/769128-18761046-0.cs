    public partial class Device_Options : Form
        {
    
            public Device_Options()
            {
                InitializeComponent();      
                deviceLabel.Text = devices.selectedDevice;
            }
    
     public Device_Options(Device selectedDevice)
            {
                InitializeComponent();      
                deviceLabel.Text = selectedDevice;
            }
    }

    using OpenHardwareMonitor.Hardware;
.
.
.
    public partial class mainWindow : Form
    {
        Computer myComputer;
        public mainWindow()
        {
            InitializeComponent();
            
            myComputer = new Computer();
            myComputer.Open();
            myComputer.GPUEnabled = true;
            myComputer.CPUEnabled = true;
            foreach (var hardwareItem in myComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            GPUtemp.Text = String.Format(sensor.Value + "°C");
                        }
                    }
                }
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            CPUtemp.Text = String.Format(sensor.Value + "°C");
                        }
                    }
                }
            }
        }
        private void valueRefresh_Tick(object sender, EventArgs e)
        {
            myComputer = new Computer();
            myComputer.Open();
            myComputer.GPUEnabled = true;
            myComputer.CPUEnabled = true;
            foreach (var hardwareItem in myComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.GpuNvidia)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            GPUtemp.Text = String.Format(sensor.Value.ToString()); // write the value to a lable on the form
                        }
                    }
                }
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {
                            CPUtemp.Text = String.Format(sensor.Value.ToString());    // write the value to a lable on the form
                        }
                    }
                }
            }
        }
    }

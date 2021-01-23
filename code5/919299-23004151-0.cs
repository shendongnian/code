    public class MyDeviceInfo : BluetoothDeviceInfo
    {
        private bool gpsSignal;
    
        MyDeviceInfo(BluetoothDeviceInfo btInfo)
    	{
    		this.Authenticated = btInfo.Authenticated;
            this.ClassOfDevice = btInfo.ClassOfDevice;
    		this.Connected = btInfo.Connected;
    		this.DeviceAddress = btInfo.DeviceAddress;
    		this.DeviceName = btInfo.DeviceName;
    	}
    	
        public MyDeviceInfo(string address) : base(address) 
        {
            gpsSignal = false;
        }
    	
        public bool GpsSignal { get { return gpsSignal; } set { gpsSignal = value;}}		
    }

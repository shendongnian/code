    public abstract class Device
    {
        DeviceSettings deviceSettings;
    
        DeviceSettings GetSettings()
        {
            return this.deviceSettings;
        }
    
        void SetSettings(DeviceSettings setting)
        {
            this.deviceSettings = setting;
        }
    }
    
    public class DevA : Device
    {
        public DevA()
        {
            this.deviceSettings = new DevASettings();
        }
    
        //Do what you need with deviceSettings here
    }
    //Repeat for DevB/DevBSettings and DevC/DevCSettings 

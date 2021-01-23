    interface IDevice
    {
        DeviceSettingsBase DeviceSetting { get; set; }
    }
    class DeviceSettingsBase
    {
        public virtual void DeviceSettingsName()
        {
            Console.WriteLine("DeviceSettingsBase");
        }
    }
    class DevA : IDevice
    {
        public DeviceSettingsBase DeviceSetting { get; set; }
    }
    class DevASettings : DeviceSettingsBase
    {
        public override void DeviceSettingsName()
        {
            Console.WriteLine("DevASettings");
        }
    }
    class DevBSettings : DeviceSettingsBase
    {
        public override void DeviceSettingsName()
        {
            Console.WriteLine("DevBSettings");
        }
    }
    public static class Example
    {
        public static void Main()
        {
            DevA devA = new DevA();
            devA.DeviceSetting = new DevASettings();
            devA.DeviceSetting.DeviceSettingsName();
            devA.DeviceSetting = new DevBSettings();
            devA.DeviceSetting.DeviceSettingsName();
            devA.DeviceSetting = new DeviceSettingsBase();
            devA.DeviceSetting.DeviceSettingsName();
        }
    }

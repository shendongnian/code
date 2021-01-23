    public interface IDevice { }
    
    public interface IDeviceA : IDevice { }
    public interface IDeviceB : IDevice { }
    
    public interface ISIBRegisterHardware2<out T> where T : class, IDevice
    {
        void DoSomething();
    }
    
    internal class DeviceA : ISIBRegisterHardware2<IDeviceA>
    {
        //...
    }
    
    internal class DeviceB : ISIBRegisterHardware2<IDeviceB>
    {
        //...
    }
    if (createDevA == true)
    {
        ISIBRegisterHardware2<IDevice> devHandle = new DeviceA();
    }
    else
    {
        ISIBRegisterHardware2<IDevice> devHandle = new DeviceB();
    }

    public interface ISIBRegisterHardware2<out T> : Register.IRegisterHardware<UInt16, UInt16> where T : class, IDevice
    {
        T Open();
    }
    
    public abstract class SIBRegisterHardware2<T> : ISIBRegisterHardware2<T> where T : class, IDevice
    {
        T ISIBRegisterHardware2<T>.Open()
        {
            return OpenInternal();
        }
    
        protected virtual T OpenInternal()
        {
            //Common logic to open.
        }
    }
    
    internal class DeviceA : SIBRegisterHardware2<IDeviceA>
    {
        //...
    }
    
    internal class DeviceB : SIBRegisterHardware2<IDeviceB>
    {
        //...
    }
    ISIBRegisterHardware2<IDevice> devHandle;
    if (createDevA == true)
    {
        devHandle = new DeviceA();
    }
    else
    {
        devHandle = new DeviceB();
    }
    devHandle.Open();

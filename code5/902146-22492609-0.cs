    public interface IDeviceSpecialArgs
    {
        string Command { get; set; }
        string Request { get; set;}
    }
    public interface IDevice
    {
        event EventHandler<IDeviceSpecialArgs> Command;
    }

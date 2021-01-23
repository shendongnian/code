    public interface IDeviceSpecialArgs
    {
        string Command { get; }
        string Request { get; }
    }
    public interface IDevice
    {
        event EventHandler<IDeviceSpecialArgs> Command;
    }

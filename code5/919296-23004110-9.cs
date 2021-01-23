    public interface IMyDeviceInfo : IComparable
    {
        BluetoothDeviceInfo(BluetoothAddress address);
        bool Authenticated { get; }
        ClassOfDevice ClassOfDevice { get; }
        bool Connected { get; }
        BluetoothAddress DeviceAddress { get; }
        string DeviceName { get; set; }
        ...
    }

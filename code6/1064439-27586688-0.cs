    // No MyHandler on any of the concrete classes
    [MyHandler]
    public interface IDevice
    { /* omitted */ }
    [MyHandler]
    public interface ISerialDevice : IDevice
    { /* omitted */ }
    [MyHandler]
    public interface IProtocolSerialDevice : ISerialDevice
    { /* omitted */ }
    [MyHandler]
    public interface ICustomSerialDevice : IProtocolSerialDevice
    { /* omitted */ }

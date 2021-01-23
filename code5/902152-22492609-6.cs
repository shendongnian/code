    public sealed class DeviceSpecialArgs : EventArgs, IDeviceSpecialArgs
    {
        private readonly string command;
        private readonly string request;
        public string Command
        {
            get { return command; }
        }
        public string Request
        {
            get { return request; }
        }
        public DeviceSpecialArgs(string command, string request)
        {
            this.command = command;
            this.request = request;
        }
    }
    public class Device : IDevice
    {
        public event EventHandler<IDeviceSpecialArgs> Command;
        ...
    }

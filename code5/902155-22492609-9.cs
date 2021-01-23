    internal class DeviceEvent
    {
        private readonly Type deviceType;
        private readonly Type deviceSpecialArgsType;
        public DeviceEvent()
        {
            // Load the assembly
            const string dllPath = @"C:\Temp\Device.dll";
            Assembly asm = Assembly.LoadFrom(dllPath);
            // Get types
            deviceType = asm.GetType("Device");
            deviceSpecialArgsType = asm.GetType("DeviceSpecialArgs");
            // Instantiate Device
            object device = Activator.CreateInstance(deviceType);
            // Subscribe to the Command event
            deviceType.GetEvent("Command").AddEventHandler(device, (Delegate.CreateDelegate(typeof(EventHandler), GetType().GetMethod("Device_Command"))));
        }
        private void Device_Command(object sender, EventArgs e)
        {
            string command = deviceSpecialArgsType.GetProperty("Command").GetValue(e, null).ToString();
            string request = deviceSpecialArgsType.GetProperty("Request").GetValue(e, null).ToString();
        }
    }

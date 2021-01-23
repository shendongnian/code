    // Add the following lines inside the ProcessHub function
    // inside the "if (port.IsDeviceConnected)" statement
    // Leave everything else as is
    if (port.IsDeviceConnected)
    {
       // ...
       sb.AppendLine("SerialNumber=" + device.SerialNumber);
       // Add these three lines
       sb.AppendLine("DeviceClass=0x" + device.DeviceClass.ToString("X"));
       sb.AppendLine("DeviceSubClass=0x" + device.DeviceSubClass.ToString("X"));
       sb.AppendLine("DeviceProtocol=0x" + device.DeviceProtocol.ToString("X"));
       // ...
    }

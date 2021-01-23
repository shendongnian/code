    // Hardware check
    using (ManagementObjectSearcher deviceSearcher = new ManagementObjectSearcher("Select Name, Status from Win32_PnPEntity"))
    using (ManagementObjectCollection devices = deviceSearcher.Get())
    {
            // Enumerate the devices
            foreach (ManagementObject device in devices)
            {
                // To make the example more simple,
                string name = (string)device.GetPropertyValue("Name") ?? string.Empty;
                string status = (string)device.GetPropertyValue("Status") ?? string.Empty;
                // Uncomment these lines and use the "select * query" if you 
                // want a VERY verbose list
                // foreach (PropertyData prop in device.Properties)
                //    Console.WriteLine("\t{0}: {1}", prop.Name, prop.Value);
                // More details on the valid properties:
                // 
                Console.WriteLine("Device name: {0}", name);
                Console.WriteLine("\tStatus: {0}", status);
                // Part II, Evaluate the device status.
                bool working = status == "OK" || status == "Degraded" || status == "Pred Fail";
                Console.WriteLine("\tWorking?: {0}", working);
            }
    }

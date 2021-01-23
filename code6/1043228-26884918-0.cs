    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Usb_Test
    {
        class Program
        {
            private static List<USBDeviceInfo> previousDecices = new List<USBDeviceInfo>();
    
            static void Main(string[] args)
            {
                Thread thread = new Thread(DeviceDetection);
                thread.Start();
    
                Console.Read();
            }
    
            static void DeviceDetection()
            {
                while (true)
                {
                    List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
    
                    ManagementObjectCollection collection;
                    using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                        collection = searcher.Get();
    
                    foreach (var device in collection)
                    {
                        devices.Add(new USBDeviceInfo(
                        (string)device.GetPropertyValue("DeviceID")
                        ));
                    }
    
                    if (previousDecices == null || !previousDecices.Any()) // So we don't detect already plugged in devices the first time.
                        previousDecices = devices;
    
                    var insertionDevices = devices.Where(d => !previousDecices.Any(d2 => d2.DeviceID == d.DeviceID));
                    if (insertionDevices != null && insertionDevices.Any())
                    {
                        foreach(var value in insertionDevices)
                        {
                            Console.WriteLine("Inserted: " + value.DeviceID); // Add your own event for the insertion of devices.
                        }
                    }    
    
                    var removedDevices = previousDecices.Where(d => !devices.Any(d2 => d2.DeviceID == d.DeviceID));
                    if (removedDevices != null && removedDevices.Any())
                    {
                        foreach (var value in removedDevices)
                        {
                            Console.WriteLine("Removed: " + value.DeviceID); // Add your own event for the removal of devices.
                        }
                    }
    
                    previousDecices = devices;
                    collection.Dispose();
                }
            }
        }
    
        class USBDeviceInfo
        {
            public USBDeviceInfo(string deviceID)
            {
                this.DeviceID = deviceID;
            }
            public string DeviceID { get; private set; }
    
        }
    }

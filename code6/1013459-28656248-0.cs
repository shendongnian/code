    using InTheHand.Net;
    using InTheHand.Net.Bluetooth;
    using InTheHand.Net.Bluetooth.Widcomm;
    using InTheHand.Net.Sockets;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    using System.Text.RegularExpressions;
    
    namespace SearchDevice
    {
        class Program
        {
            static void Main(string[] args)
            {
            
                string FriendlyDeviceName =  "T-S460-BT2";
                
                if (BluetoothRadio.IsSupported)
                {
                    BluetoothClient client = new BluetoothClient();
                    BluetoothDeviceInfo[] devices;
                    devices = client.DiscoverDevicesInRange();
                    foreach (BluetoothDeviceInfo d in devices)
                    {
                        if (Regex.IsMatch(d.DeviceName, FriendlyDeviceName, RegexOptions.IgnoreCase))
                        {
                            try
                            {
                                string query = string.Format("SELECT Name, DeviceID, PNPDeviceID from WIN32_SerialPort");
                                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                                ManagementObjectCollection osDetailsCollection = searcher.Get();
                                foreach (ManagementObject mo in osDetailsCollection)
                                {
                                    string PNPDeviceID = (string)mo.GetPropertyValue("PNPDeviceID");
                                    if (PNPDeviceID != null && Regex.IsMatch(PNPDeviceID, d.DeviceAddress + "", RegexOptions.IgnoreCase))
                                    {
                                        Console.WriteLine("{0}", ((string)mo.GetPropertyValue("DeviceId")).Replace("COM", ""));
                                    }
                                }
                            }
                            catch (Exception exx)
                            {
    
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not Supported");
                }
    
                Console.ReadLine();
    
            }
        }
    }
 

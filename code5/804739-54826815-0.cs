            ManagementClass wmi = new ManagementClass("Win32_OperatingSystem");
            foreach (var item in wmi.GetInstances())
            {
                string serialNumber = Convert.ToString(item["SerialNumber"]);
                Console.WriteLine(serialNumber);
            }
 

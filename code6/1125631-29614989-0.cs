      public static void Main()
        {
            try
            {
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher("root\\WMI", 
                    "SELECT * FROM MSAcpi_ThermalZoneTemperature"); 
                              foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("MSAcpi_ThermalZoneTemperature instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("CurrentTemperature: {0}", queryObj["CurrentTemperature"]);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }

    private static bool DoesMseExist()
    {
           using (RegistryKey localMachineX64View = 
                        RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                        RegistryView.Registry64))
           {
               using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
               {
                   foreach (string subKey in rk.GetSubKeyNames())
                   {
                       using (RegistryKey productKey = rk.OpenSubKey(subKey))
                       {
                           if (productKey != null)
                           {
                               if (Convert.ToString(productKey.GetValue("DisplayName"))
                                  .Contains("Microsoft Security Client"))
                               {
                                   return true;
                               }
                           }
                       }
                   }
               }
          }
          return false;
    }

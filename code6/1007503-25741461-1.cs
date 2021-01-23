            RegistryKey registry = Registry.LocalMachine.OpenSubKey(@"software\newclient", true);            
            if (registry == null)
            {
                Registry.LocalMachine.CreateSubKey(@"software\newclient");
                registry = Registry.LocalMachine.OpenSubKey(@"software\newclient", true);
            }
            if (registry.GetValue("CreatedTime")==null)
            {
                registry.SetValue("CreatedTime", "1/1/1900 00:00 PM");
            }
            if (registry.GetValue("CurrentVersion") == null)
            {
                registry.SetValue("CurrentVersion", "0.0.0.0");
            }
            if (Convert.ToDateTime(registry.GetValue("CreatedTime").ToString()) != Convert.ToDateTime(arr[1]))
            {
                /*
                 * other code snippet
                 *
                 */
                registry.SetValue("CurrentVersion",arr[0]);
                registry.SetValue("CreatedTime", arr[1]);
                return true;
            }
            registry.Close();
            return false;
        

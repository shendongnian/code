    public static IEnumerable<string> GetInstalledApps()
    {    
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key);
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(subkey_name);
                {
                    // I've also added fix for what I believe that was a "silent bug" 
                    // that allowed entries without a display name to be "lost".
                    // This code returns the subkey name if there is no display name.
                    var value = subkey.GetValue("DisplayName") as string;
                    if (!string.IsNullOrEmpty(value)) {
                        yield return value;
                    } else {
                        // No display name, but there is still an entry!!                
                        yield return subkey_name;
                    }
                }
            }
        }
    }

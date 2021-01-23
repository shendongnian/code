    public static IEnumerable<string> GetInstalledApps()
    {    
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key);
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(subkey_name);
                {
                    // I've also added a guard here so we don't get null/empty values.
                    // I didn't do this in the previous example because WriteLine(nullString)
                    // very nicely writes nothing (and does not throw an Exception).
                    var value = subkey.GetValue("DisplayName") as string;
                    if (!string.IsNullOrEmpty(value)) {
                        yield return value;
                    }
                }
            }
        }
    }

    public static void GetInstalledApps(TextWriter writer)
    {    
        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key);
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(subkey_name);
                {
                    // While this won't throw an Exception when GetValue returns null,
                    // as WriteLine will "output nothing" for null values,
                    // this logic might be bugged: the next example has a possible solution.
                    // No more hard-coding of Console.WriteLine, instead we use
                    // writer.WriteLine, where writer is the TextWriter that
                    // has been supplied as an argument.
                    writer.WriteLine(subkey.GetValue("DisplayName"));
                }
            }
        }
    }

    var key = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
    RegistryKey registryKeys = 
        Registry.LocalMachine.OpenSubKey(key);
    var maxLength = registryKeys.GetValueNames().Max(n => n.Length);
    foreach (string registryKey in registryKeys.GetValueNames())
    {
        Console.WriteLine("{0}:{1}", 
            registryKey.PadRight(maxLength), 
            registryKeys.GetValue(registryKey));
    }

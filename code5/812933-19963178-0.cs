        //Check the 64-bit registry for "HKEY_LOCAL_MACHINE\SOFTWARE" 1st:
        RegistryKey localMachineRegistry64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
        RegistryKey reg64 = localMachineRegistry64.OpenSubKey(registryKeyLocation, false);
        if (reg64 != null)
        {
            return reg64.GetValue(registryKeyName, true).ToString();
        }
        //Check the 32-bit registry for "HKEY_LOCAL_MACHINE\SOFTWARE" if not found in the 64-bit registry:
        RegistryKey localMachineRegistry32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
        RegistryKey reg32 = localMachineRegistry32.OpenSubKey(registryKeyLocation, false);
        if (reg32 != null)
        {
            return reg32.GetValue(registryKeyName, true).ToString();
        }

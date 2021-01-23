    // Open the Display Reg-Key
    RegistryKey displayRegistry = Registry.LocalMachine;
    Boolean isFailed = false;
    try
    {
        displayRegistry = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\DISPLAY");
    }
    catch
    {
        isFailed = true;
    }
    if (!isFailed & (displayRegistry != null))
    {
        // Get all MonitorIDss
        foreach (String monitorID in displayRegistry.GetSubKeyNames())
        {
            if (monitorID == name)
            {
                RegistryKey monitorIDRegistry = displayRegistry.OpenSubKey(monitorID);
                if (monitorIDRegistry != null)
                {
                    // Get all Plug&Play ID's
                    foreach (String subname in monitorIDRegistry.GetSubKeyNames())
                    {
                        RegistryKey pnpID = monitorIDRegistry.OpenSubKey(subname);
                        if (pnpID != null)
                        {
                            String[] subkeys = pnpID.GetSubKeyNames();
                            // Check if Monitor is active
                            if (subkeys.Contains("Control"))
                            {
                                if (subkeys.Contains("Device Parameters"))
                                {
                                    RegistryKey devParam = pnpID.OpenSubKey("Device Parameters");
                                    Int16 sizeH = 0;
                                    Int16 sizeV = 0;
                                    // Get the EDID code
                                    byte[] edidObj = devParam.GetValue("EDID", null) as byte[];
                                    if (edidObj != null)
                                    {
                                        sizeH = Convert.ToInt16(Encoding.Default.GetString(edidObj, 0x15, 1)[0]);
                                        sizeV = Convert.ToInt16(Encoding.Default.GetString(edidObj, 0x16, 1)[0]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Map the drive letter mapped by the drive ID
    /// </summary>
    /// <param name="driveId">The guid of the drive</param>
    static string MapDriveLetter(string driveId)
    {
        const string registryPath = @"SYSTEM\MountedDevices";
        RegistryKey reg = Registry.LocalMachine.OpenSubKey(registryPath);
        string[] readIn = reg.GetValueNames();
        byte[] keyCode = {};
        Regex regGuid = new Regex(@"\{[^\}]+\}");
        Regex regDriveLetter = new Regex(@"[A-Z]:$");
        foreach (string keyRead in readIn) {
            if (regGuid.IsMatch(keyRead) && regGuid.Match(keyRead).Value == driveId )
                keyCode = (byte[])reg.GetValue(keyRead, null);                
        }
        foreach (string keyRead in readIn)
        {
            byte[] codeRead = (byte[])reg.GetValue(keyRead, null);
            if (!regGuid.IsMatch(keyRead) && keyCode.SequenceEqual(codeRead))
            {
                if (regDriveLetter.IsMatch(keyRead)) // Get the drive letter in the form "E:"
                    return regDriveLetter.Match(keyRead).Value;
            }
        }
        return string.Empty;
    }

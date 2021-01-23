    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
    public static extern long WriteValueA(string section, 
                                           string key, 
                                           string val, 
                                           string filePath);

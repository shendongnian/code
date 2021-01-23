    [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CharSet = CharSet.Unicode)]
    private static extern long WriteValueA(string section, string key, string val, string filePath);
    public void IniWriteValue(string Section, string Key, string Value)
        {
            WriteValueA(Section, Key, Value, this.path);
        }

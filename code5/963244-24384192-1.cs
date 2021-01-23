    public void updateSharedSection(int z)
    {
        updateSharedSection(-1, -1, z);
    }
    
    public void updateSharedSection(int x, int y, int z)
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Session Manager\\SubSystems", true);
        key.SetValue("Windows", _sharedSection(x, y, z, key.GetValue("Windows").ToString()));
    }
    
    /// <param name="x">the maximum size of the system-wide heap (in kilobytes) / -1 by default</param>
    /// <param name="y">the size of each desktop heap / -1 by default</param>
    /// <param name="z"> the size of the desktop heap that is associated with a non-interactive Windows station / -1 by default</param>
    /// <param name="raw">raw data line</param>
    /// <returns></returns>
    private string _sharedSection(int x, int y, int z, string raw)
    {
        Func<int, string, string> setVal = delegate(int xyz, string def) {
            return (xyz == -1) ? def : xyz.ToString();
        };
    
        return Regex.Replace(raw, @"SharedSection=(\d+),(\d+),(\d+)", delegate(Match m)
        {
            return string.Format(
                "SharedSection={0},{1},{2}", 
                    setVal(x, m.Groups[1].Value),
                    setVal(y, m.Groups[2].Value),
                    setVal(z, m.Groups[3].Value));
        }, 
        RegexOptions.IgnoreCase);
    }

    public enum DepSystemPolicyType
    {
        AlwaysOff = 0,
        AlwaysOn,
        OptIn,
        OptOut
    }
    [DllImport("kernel32.dll")]
    static extern int GetSystemDEPPolicy();
    public static void ValidateDepPolicy()
    {
        int policy = GetSystemDEPPolicy();
        //here you can evaluate the return value
        //against the enum DepSystemPolicyType
    }

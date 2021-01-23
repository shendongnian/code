    [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
    internal static extern bool GetProductInfo(
    int osMajorVersion,
    int osMinorVersion,
    int spMajorVersion,
    int spMinorVersion,
    out int ProdunctNum); 
    GetProductInfo(
    Environment.OSVersion.Version.Major,
    Environment.OSVersion.Version.Minor,
    0,
    0,
    out ProdunctNum); 

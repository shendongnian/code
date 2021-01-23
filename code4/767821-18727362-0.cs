    [DllImport(MonoTouch.Constants.SystemLibrary)]  
    internal static extern int sysctlbyname( [MarshalAs(UnmanagedType.LPStr)] string property, byte[] output, ref Int64 oldLen, IntPtr newp, uint newlen);
    public static string SystemStringInfo(string property)
    {
        GCHandle? lenh = null, valh = null;
        Int64 len = 0L;
        byte[] val;
        int status = sysctlbyname(property, null, ref len, IntPtr.Zero, 0);
        if (status == 0)
        {
            val = new byte[(Int64) len];
            status = sysctlbyname(property, val, ref len, IntPtr.Zero, 0);
            if (status == 0)
            {
                return Encoding.UTF8.GetString(val);
            }
        }
        return null;
    }

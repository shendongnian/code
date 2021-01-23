    [ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    Guid("9068270B-0939-11D1-8BE1-00C04FD8D503")]
    public interface IADsLargeInteger
    {
        int HighPart{get;set;}
        int LowPart{get;set;}
    }
    private DateTime? GetLockoutTime(DirectoryEntry de)
    {
        DateTime? ret = null;
        IADsLargeInteger largeInt = de.Properties["lockoutTime"].Value as IADsLargeInteger;
        
        if (largeInt != null)
        {
            long ticks = (long)largeInt.HighPart << 32 | largeInt.LowPart;
            // 0 means not lockout
            if (ticks != 0)
            {
                ret = DateTime.FromFileTimeUtc(ticks.Value);
            }
        }
        return ret;
    }

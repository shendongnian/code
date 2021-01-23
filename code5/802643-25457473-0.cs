     class PInvoke {
    [DllImport("Netapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int DsGetDcName
            (
              [MarshalAs(UnmanagedType.LPTStr)]
                string ComputerName,
              [MarshalAs(UnmanagedType.LPTStr)]
                string DomainName,
              [In] int DomainGuid,
              [MarshalAs(UnmanagedType.LPTStr)]
                string SiteName,
              [MarshalAs(UnmanagedType.U4)]
                DSGETDCNAME_FLAGS flags,
              out IntPtr pDOMAIN_CONTROLLER_INFO
            );
        [StructLayout(LayoutKind.Sequential)]
        public class GuidClass
        {
            public Guid TheGuid;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DOMAIN_CONTROLLER_INFO
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DomainControllerName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DomainControllerAddress;
            public uint DomainControllerAddressType;
            public Guid DomainGuid;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DomainName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DnsForestName;
            public uint Flags;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string DcSiteName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string ClientSiteName;
        }
        [DllImport("Netapi32.dll", SetLastError = true)]
        public static extern int NetApiBufferFree(IntPtr Buffer);
        [Flags]
        public enum DSGETDCNAME_FLAGS : uint
        {
            DS_FORCE_REDISCOVERY = 0x00000001,
            DS_DIRECTORY_SERVICE_REQUIRED = 0x00000010,
            DS_DIRECTORY_SERVICE_PREFERRED = 0x00000020,
            DS_GC_SERVER_REQUIRED = 0x00000040,
            DS_PDC_REQUIRED = 0x00000080,
            DS_BACKGROUND_ONLY = 0x00000100,
            DS_IP_REQUIRED = 0x00000200,
            DS_KDC_REQUIRED = 0x00000400,
            DS_TIMESERV_REQUIRED = 0x00000800,
            DS_WRITABLE_REQUIRED = 0x00001000,
            DS_GOOD_TIMESERV_PREFERRED = 0x00002000,
            DS_AVOID_SELF = 0x00004000,
            DS_ONLY_LDAP_NEEDED = 0x00008000,
            DS_IS_FLAT_NAME = 0x00010000,
            DS_IS_DNS_NAME = 0x00020000,
            DS_RETURN_DNS_NAME = 0x40000000,
            DS_RETURN_FLAT_NAME = 0x80000000
        }
    }
    class domain
    {
       public static void DetectDc(string domain, string username, string password, out string dc, out string dcAddress, out string path)
            {
                PInvoke.DOMAIN_CONTROLLER_INFO domainInfo;
                const int errorSuccess = 0;
                var pDci = IntPtr.Zero;
    
                try
                {
                    var val = PInvoke.DsGetDcName(null, domain, 0, "", 0, out pDci);
                    //check return value for error
                    if (errorSuccess == val)
                    {
                        domainInfo = (PInvoke.DOMAIN_CONTROLLER_INFO)Marshal.PtrToStructure(pDci, typeof(PInvoke.DOMAIN_CONTROLLER_INFO));
                    }
                    else
                    {
                        dc = "";
                        dcAddress = "";
                        path = "";
                        namingContext = "";
                        return;
                    }
                }
                finally
                {
                    PInvoke.NetApiBufferFree(pDci);
                }
    
                dc = domainInfo.DomainControllerName;
                dc = dc.Replace("\\\\", "");
    
                dcAddress = domainInfo.DomainControllerAddress;
                dcAddress = dcAddress.Replace("\\\\", "");
    
                var ldap = new Ldap(domain, dcAddress, username, password);
    
            }
    }

    class Program
    {
        static void Main(string[] args) {
            var data = ...;
            var cms = new SignedCms();
            cms.Decode(data);
            var pbCmsgSignerInfo = typeof(SignerInfo).GetField("m_pbCmsgSignerInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            var si = (SafeHandle)pbCmsgSignerInfo.GetValue(cms.SignerInfos[0]);
            var safeCryptMessageHandle = typeof(SignedCms).GetField("m_safeCryptMsgHandle", BindingFlags.NonPublic | BindingFlags.Instance);
            var hMsg = (SafeHandle)safeCryptMessageHandle.GetValue(cms);
            var vsi = new CRYPTUI_VIEWSIGNERINFO_STRUCT {
                dwSize = (uint)Marshal.SizeOf(typeof(CRYPTUI_VIEWSIGNERINFO_STRUCT)),
                pSignerInfo = si,
                hMsg = hMsg,
            };
            CryptUIDlgViewSignerInfo(ref vsi);
        }
        [DllImport("Cryptui.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CryptUIDlgViewSignerInfo(ref CRYPTUI_VIEWSIGNERINFO_STRUCT pcvsi);
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct CRYPTUI_VIEWSIGNERINFO_STRUCT
    {
        public UInt32 dwSize;
        public IntPtr hwndParent;
        public UInt32 dwFlags;
        public string szTitle;
        public SafeHandle pSignerInfo;
        public SafeHandle hMsg;
        
        [MarshalAs(UnmanagedType.LPStr)]
        public string pszOID;
        public UInt32 dwReserved;
        public UInt32 cStores;
        public IntPtr rghStores;
        public UInt32 cPropSheetPages;
        public IntPtr rgPropSheetPages;
    }

    namespace StiWorks
    {
    //COPY OF https://github.com/ryanmcdonnell/ScanToEvernote/blob/c8fd7dfed041950499afe7578700199461a37c65/ScanToEvernote/Sti.cs
    
    public enum STI_DEVICE_TYPE : int
    {
        StiDeviceTypeDefault = 0,
        StiDeviceTypeScanner = 1,
        StiDeviceTypeDigitalCamera = 2,
        StiDeviceTypeStreamingVideo = 3
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STI_DEV_CAPS
    {
        public int dwGeneric;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STI_DEVICE_INFORMATIONW
    {
        private const int STI_MAX_INTERNAL_NAME_LENGTH = 128;
        public int dwSize;
        public STI_DEVICE_TYPE DeviceType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = STI_MAX_INTERNAL_NAME_LENGTH)]
        string szDeviceInternalName;
        public STI_DEV_CAPS DeviceCapabilities;
        public int dwHardwareConfiguration;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszVendorDescription;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszDeviceDescription;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszPortName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszPropProvider;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pszLocalName;
    }
    [Guid("641BD880-2DC8-11D0-90EA-00AA0060F86C"), // IStillImageW
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStillImage // cannot list any base interfaces here
    {
        // note that IUnknown Interface members are NOT listed here
        void Initialize(IntPtr hinst, [In] int dwVersion);
        void GetDeviceList([In] int dwType, [In] int dwFlags, [Out] out int pdwItemsReturned, [In, Out] IntPtr ppBuffer);
        void GetDeviceInfo([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName, [In, Out] IntPtr ppBuffer);
        void CreateDevice([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName, [In] int dwMode, [In, Out] IntPtr pDevice, [In, Out] IntPtr punkOuter);
        void GetDeviceValue([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName, [In, MarshalAs(UnmanagedType.LPWStr)] string pValueName, [In, Out] ref int pType, [In, Out] StringBuilder pData, [In, Out] ref int cbData);
        void SetDeviceValue([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName, [In, MarshalAs(UnmanagedType.LPWStr)] string pValueName, [In] int Type, [In, Out] IntPtr pData, [In] int cbData);
        void GetSTILaunchInformation([In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string pwszDeviceName, [In, Out] ref int pdwEventCode, [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string pwszEventName);
        void RegisterLaunchApplication([In, MarshalAs(UnmanagedType.LPWStr)] string pwszAppName, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCommandLine);
        void UnregisterLaunchApplication([In, MarshalAs(UnmanagedType.LPWStr)] string pwszAppName);
        void EnableHwNotifications([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName, [In] bool bNewState);
        void GetHwNotificationState([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName, [In, Out] ref bool pbCurrentState);
        void RefreshDeviceBus([In, MarshalAs(UnmanagedType.LPWStr)] string pwszDeviceName);
        void LaunchApplicationForDevice([In, MarshalAs(UnmanagedType.LPWStr)]
                string pwszDeviceName, [In, MarshalAs(UnmanagedType.LPWStr)] string
                pwszAppName, [In, Out] IntPtr pStiNofify);
        void SetupDeviceParameters([In, Out] ref STI_DEVICE_INFORMATIONW pDeviceInfo);
        void WriteToErrorLog([In] int dwMessageType, [In, MarshalAs(UnmanagedType.LPWStr)] string pszMessage);
    }
    [ComImport, Guid("B323F8E0-2E68-11D0-90EA-00AA0060F86C")]
    public class Sti
    {
    }

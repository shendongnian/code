    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DISPLAY_DEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }
    [Flags]
    public enum DisplayDeviceStateFlags : int
    {
        /// <summary>The device is part of the desktop.</summary>
        AttachedToDesktop = 0x1,
        MultiDriver = 0x2,
        /// <summary>The device is part of the desktop.</summary>
        PrimaryDevice = 0x4,
        /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
        MirroringDriver = 0x8,
        /// <summary>The device is VGA compatible.</summary>
        VGACompatible = 0x10,
        /// <summary>The device is removable; it cannot be the primary display.</summary>
        Removable = 0x20,
        /// <summary>The device has more display modes than its output devices support.</summary>
        ModesPruned = 0x8000000,
        Remote = 0x4000000,
        Disconnect = 0x2000000
    }
    [DllImport("User32.dll")]
    public static extern int EnumDisplayDevices(string lpDevice, int iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);
    private static List<NativeMethods.DISPLAY_DEVICE> GetAllDevice()
    {
        List<NativeMethods.DISPLAY_DEVICE> devices = new List<NativeMethods.DISPLAY_DEVICE>();
        bool error = false;
        for (int devId = 0; !error; devId++)
        {
            try
            {
                NativeMethods.DISPLAY_DEVICE device = new NativeMethods.DISPLAY_DEVICE();
                device.cb = Marshal.SizeOf(typeof(NativeMethods.DISPLAY_DEVICE));
                error = NativeMethods.EnumDisplayDevices(null, devId, ref device, 0) == 0;
                if (String.IsNullOrWhiteSpace(device.DeviceID) == false)
                {
                    devices.Add(device);
                }
            }
            catch (Exception)
            {
                error = true;
            }
        }
        return devices;
    }

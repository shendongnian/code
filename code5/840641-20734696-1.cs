    [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern Boolean GetVolumeNameForVolumeMountPoint(String mountPoint, StringBuilder name, UInt32 bufferLength);
    
    private enum FileAccess : uint
    {
        GenericReadWrite = 0x80000000 | 0x40000000 // GENERIC_READ | GENERIC_WRITE
    }
    
    private enum FileShare : uint
    {
        ReadWriteDelete = 0x00000001 | 0x00000002 | 0x00000004 // FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE
    }
    
    private enum FileCreation : uint
    {
        OpenExisting = 3 // OPEN_EXISTING
    }
    
    private enum FileFlags : uint
    {
        None = 0
    }
    
    [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CreateFile(String fileName, FileAccess access, FileShare share, IntPtr secAttr,
        FileCreation creation, FileFlags flags, IntPtr templateFile);
    
    [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern Boolean CloseHandle(IntPtr handle);
    
    private enum IoControlCode
    {
        GetVolumeDiskExtents = 0x00560000 // IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS
    }
    
    [StructLayout(LayoutKind.Explicit)]
    private struct VolumeDiskExtents
    {
        [FieldOffset(0)]
        public UInt32 numberOfDiskExtents;
        [FieldOffset(8)]
        public UInt32 diskNumber;
        [FieldOffset(16)]
        public Int64 startingOffset;
        [FieldOffset(24)]
        public Int64 extentLength;
    }
    
    [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern Boolean DeviceIoControl(IntPtr device, IoControlCode controlCode, IntPtr inBuffer, UInt32 inBufferSize,
        ref VolumeDiskExtents extents, UInt32 outBufferSize, ref UInt32 bytesReturned, IntPtr overlapped);
    
    public class PhysicalDisk
    {
        public PhysicalDisk(String physicalName, String model, String interfaceType, String serialNumber)
        {
            this.PhysicalName = physicalName;
            this.Model = model;
            this.InterfaceType = interfaceType;
            this.SerialNumber = serialNumber;
        }
        public String PhysicalName { get; private set; }
        public String Model { get; private set; }
        public String InterfaceType { get; private set; }
        public String SerialNumber { get; private set; }
    }
    
    public PhysicalDisk GetPhysicalDiskFromCurrentDrive()
    {
        //
        // Get the drive letter of the drive the executable was loaded from.
        //
        var basePath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("file:///", "");
        var driveLetter = System.IO.Path.GetPathRoot(basePath);
        // TODO: Validate driveLetter; could also be a UNC path.
        //
        // Get the volume name of the drive letter.
        //
        var volumeNameBuffer = new StringBuilder(65536);
        if (!GetVolumeNameForVolumeMountPoint(driveLetter, volumeNameBuffer, (UInt32)volumeNameBuffer.Capacity))
            throw new Win32Exception();
        var volumeName = volumeNameBuffer.ToString().TrimEnd('\\'); // Remove trailing backslash
        //
        // Open the volume and retrieve the disk number.
        //
        UInt32 diskNumber;
        IntPtr volume = IntPtr.Zero;
        try
        {
            volume = CreateFile(volumeName, FileAccess.GenericReadWrite, FileShare.ReadWriteDelete, IntPtr.Zero,
                FileCreation.OpenExisting, FileFlags.None, IntPtr.Zero);
            if (volume == (IntPtr)(-1))
                throw new Win32Exception();
            VolumeDiskExtents extents = new VolumeDiskExtents();
            UInt32 bytesReturned = 0;
            if (!DeviceIoControl(volume, IoControlCode.GetVolumeDiskExtents, IntPtr.Zero, 0,
                ref extents, (UInt32)Marshal.SizeOf(extents), ref bytesReturned, IntPtr.Zero))
            {
                // Partitions can span more than one disk, we will ignore this case for now.
                // See http://msdn.microsoft.com/en-us/library/windows/desktop/aa365727(v=vs.85).aspx
                if (Marshal.GetLastWin32Error() != 234 /*ERROR_MORE_DATA*/)
                    throw new Win32Exception();
            }
            diskNumber = extents.diskNumber;
        }
        finally
        {
            if (volume != IntPtr.Zero)
            {
                CloseHandle(volume);
                volume = IntPtr.Zero;
            }
        }
        //
        // Build the physical disk name from the disk number.
        //
        String physicalName = ("\\\\.\\PHYSICALDRIVE" + diskNumber).Replace("\\", "\\\\");
        //
        // Find information about the physical disk using WMI.
        //
        var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE DeviceID = \"" + physicalName + "\"");
        foreach (ManagementObject obj in searcher.Get())
        {
            return new PhysicalDisk(
                obj["DeviceID"].ToString(),
                obj["Model"].ToString(),
                obj["InterfaceType"].ToString(),
                obj["SerialNumber"].ToString()
                );
        }
        throw new InvalidOperationException();
    }

    internal class NativeMethods
    {
      internal const int ERROR_HANDLE_EOF = 38;
      //--> Privilege constants....
      internal const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
      internal const string SE_BACKUP_NAME = "SeBackupPrivilege";
      internal const string SE_RESTORE_NAME = "SeRestorePrivilege";
      internal const string SE_SECURITY_NAME = "SeSecurityPrivilege";
      internal const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
      internal const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
      internal const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
      internal const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
      internal const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
      internal const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
      internal const string SE_TCB_NAME = "SeTcbPrivilege";
      internal const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
      internal const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
      //--> For starting a process in session 1 from session 0...
      internal const int TOKEN_DUPLICATE = 0x0002;
      internal const uint MAXIMUM_ALLOWED = 0x2000000;
      internal const int CREATE_NEW_CONSOLE = 0x00000010;
      internal const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
      internal const int TOKEN_QUERY = 0x00000008;
      [DllImport( "advapi32.dll", SetLastError = true )]
      [return: MarshalAs( UnmanagedType.Bool )]
      internal static extern bool OpenProcessToken( IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle );
      [DllImport( "kernel32.dll" )]
      internal static extern IntPtr GetCurrentProcess( );
      [DllImport( "advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
      [return: MarshalAs( UnmanagedType.Bool )]
      internal static extern bool LookupPrivilegeValue( string lpSystemName, string lpName, out LUID lpLuid );
      [DllImport( "advapi32.dll", SetLastError = true )]
      [return: MarshalAs( UnmanagedType.Bool )]
      internal static extern bool AdjustTokenPrivileges( IntPtr TokenHandle, [MarshalAs( UnmanagedType.Bool )]bool DisableAllPrivileges, ref TOKEN_PRIVILEGES NewState, Int32 BufferLength, IntPtr PreviousState, IntPtr ReturnLength );
      [DllImport( "kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode )]
      [return: MarshalAs( UnmanagedType.Bool )]
      internal static unsafe extern bool DeviceIoControl( IntPtr hDevice, DeviceIOControlCode controlCode, byte* lpInBuffer, uint nInBufferSize, byte* lpOutBuffer, uint nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped );
      [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode )]
      internal static extern SafeFileHandle CreateFile( string lpFileName, EFileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile );
      [DllImport( "kernel32.dll", SetLastError = true )]
      [return: MarshalAs( UnmanagedType.Bool )]
      internal static extern bool CloseHandle( IntPtr hObject );
      [Flags]
      internal enum EMethod: uint
      {
        Buffered = 0,
        InDirect = 1,
        OutDirect = 2,
        Neither = 3
      }
      [Flags]
      internal enum EFileAccess: uint
      {
        GenericRead = 0x80000000,
        GenericWrite = 0x40000000,
        GenericExecute = 0x20000000,
        GenericAll = 0x10000000,
        Delete = 0x10000,
        ReadControl = 0x20000,
        WriteDAC = 0x40000,
        WriteOwner = 0x80000,
        Synchronize = 0x100000,
        StandardRightsRequired = 0xF0000,
        StandardRightsRead = ReadControl,
        StandardRightsWrite = ReadControl,
        StandardRightsExecute = ReadControl,
        StandardRightsAll = 0x1F0000,
        SpecificRightsAll = 0xFFFF,
        AccessSystemSecurity = 0x1000000,
        MaximumAllowed = 0x2000000
      }
      [Flags]
      internal enum EFileDevice: uint
      {
        Beep = 0x00000001,
        CDRom = 0x00000002,
        CDRomFileSytem = 0x00000003,
        Controller = 0x00000004,
        Datalink = 0x00000005,
        Dfs = 0x00000006,
        Disk = 0x00000007,
        DiskFileSystem = 0x00000008,
        FileSystem = 0x00000009,
        InPortPort = 0x0000000a,
        Keyboard = 0x0000000b,
        Mailslot = 0x0000000c,
        MidiIn = 0x0000000d,
        MidiOut = 0x0000000e,
        Mouse = 0x0000000f,
        MultiUncProvider = 0x00000010,
        NamedPipe = 0x00000011,
        Network = 0x00000012,
        NetworkBrowser = 0x00000013,
        NetworkFileSystem = 0x00000014,
        Null = 0x00000015,
        ParallelPort = 0x00000016,
        PhysicalNetcard = 0x00000017,
        Printer = 0x00000018,
        Scanner = 0x00000019,
        SerialMousePort = 0x0000001a,
        SerialPort = 0x0000001b,
        Screen = 0x0000001c,
        Sound = 0x0000001d,
        Streams = 0x0000001e,
        Tape = 0x0000001f,
        TapeFileSystem = 0x00000020,
        Transport = 0x00000021,
        Unknown = 0x00000022,
        Video = 0x00000023,
        VirtualDisk = 0x00000024,
        WaveIn = 0x00000025,
        WaveOut = 0x00000026,
        Port8042 = 0x00000027,
        NetworkRedirector = 0x00000028,
        Battery = 0x00000029,
        BusExtender = 0x0000002a,
        Modem = 0x0000002b,
        Vdm = 0x0000002c,
        MassStorage = 0x0000002d,
        Smb = 0x0000002e,
        Ks = 0x0000002f,
        Changer = 0x00000030,
        Smartcard = 0x00000031,
        Acpi = 0x00000032,
        Dvd = 0x00000033,
        FullscreenVideo = 0x00000034,
        DfsFileSystem = 0x00000035,
        DfsVolume = 0x00000036,
        Serenum = 0x00000037,
        Termsrv = 0x00000038,
        Ksec = 0x00000039,
        // From Windows Driver Kit 7
        Fips = 0x0000003A,
        Infiniband = 0x0000003B,
        Vmbus = 0x0000003E,
        CryptProvider = 0x0000003F,
        Wpd = 0x00000040,
        Bluetooth = 0x00000041,
        MtComposite = 0x00000042,
        MtTransport = 0x00000043,
        Biometric = 0x00000044,
        Pmi = 0x00000045
      }
      internal enum EFileIOCtlAccess: uint
      {
        Any = 0,
        Special = Any,
        Read = 1,
        Write = 2
      }
      internal enum DeviceIOControlCode: uint
      {
        FsctlEnumUsnData = ( EFileDevice.FileSystem << 16 ) | ( 44 << 2 ) | EMethod.Neither | ( EFileIOCtlAccess.Any << 14 ),
        FsctlReadUsnJournal = ( EFileDevice.FileSystem << 16 ) | ( 46 << 2 ) | EMethod.Neither | ( EFileIOCtlAccess.Any << 14 ),
        FsctlReadFileUsnData = ( EFileDevice.FileSystem << 16 ) | ( 58 << 2 ) | EMethod.Neither | ( EFileIOCtlAccess.Any << 14 ),
        FsctlQueryUsnJournal = ( EFileDevice.FileSystem << 16 ) | ( 61 << 2 ) | EMethod.Buffered | ( EFileIOCtlAccess.Any << 14 ),
        FsctlCreateUsnJournal = ( EFileDevice.FileSystem << 16 ) | ( 57 << 2 ) | EMethod.Neither | ( EFileIOCtlAccess.Any << 14 )
      }
      /// <summary>Control structure used to interrogate MFT data using DeviceIOControl from the user volume</summary>
      [StructLayout( LayoutKind.Sequential )]
      internal struct MFTEnumDataV0
      {
        public ulong StartFileReferenceNumber;
        public long LowUsn;
        public long HighUsn;
      }
      /// <summary>A structure resurned form USN queries</summary>
      /// <remarks>
      /// FileName is synthetic...composed during a read of the structure and is not technically
      /// part of the Win32 API's definition...although the actual FileName is contained
      /// "somewhere" in the structure's trailing bytes, according to FileNameLength and FileNameOffset.
      /// 
      /// Alignment boundaries are enforced, and so, the RecordLength
      /// may be somewhat larger than the accumulated lengths of the members plus the FileNameLength.
      /// </remarks>
      [StructLayout( LayoutKind.Sequential )]
      internal struct UsnRecordV2: IBinarySerialize
      {
        public uint RecordLength;
        public ushort MajorVersion;
        public ushort MinorVersion;
        public ulong FileReferenceNumber;
        public ulong ParentFileReferenceNumber;
        public long Usn;
        public long TimeStamp;
        public UsnReason Reason;
        public uint SourceInfo;
        public uint SecurityId;
        public uint FileAttributes;
        public ushort FileNameLength;
        public ushort FileNameOffset;
        public string FileName;
        /// <remarks>Note how the read advances to the FileNameOffset and reads only FileNameLength bytes</remarks>
        public void Read( Stream stream )
        {
          var startOfRecord = stream.Position;
          RecordLength = stream.ReadUInt( );
          MajorVersion = stream.ReadUShort( );
          MinorVersion = stream.ReadUShort( );
          FileReferenceNumber = stream.ReadULong( );
          ParentFileReferenceNumber = stream.ReadULong( );
          Usn = stream.ReadLong( );
          TimeStamp = stream.ReadLong( );
          Reason = ( UsnReason ) stream.ReadUInt( );
          SourceInfo = stream.ReadUInt( );
          SecurityId = stream.ReadUInt( );
          FileAttributes = stream.ReadUInt( );
          FileNameLength = stream.ReadUShort( );
          FileNameOffset = stream.ReadUShort( );
          stream.Position = startOfRecord + FileNameOffset;
          FileName = Encoding.Unicode.GetString( stream.ReadBytes( FileNameLength ) );
          stream.Position = startOfRecord + RecordLength;
        }
        void IBinarySerialize.Write( Stream stream )
        {
          throw new NotImplementedException( );
        }
      }
      /// <summary>Structure returned from USN query that describes the state of the journal</summary>
      [StructLayout( LayoutKind.Sequential )]
      internal struct UsnJournalDataV1: IBinarySerialize
      {
        public ulong UsnJournalId;
        public long FirstUsn;
        public long NextUsn;
        public long LowestValidUsn;
        public long MaxUsn;
        public ulong MaximumSize;
        public ulong AllocationDelta;
        public ushort MinSupportedMajorVersion;
        public ushort MaxSupportedMajorVersion;
        public void Read( Stream stream )
        {
          UsnJournalId = stream.ReadULong( );
          FirstUsn = stream.ReadLong( );
          NextUsn = stream.ReadLong( );
          LowestValidUsn = stream.ReadLong( );
          MaxUsn = stream.ReadLong( );
          MaximumSize = stream.ReadULong( );
          AllocationDelta = stream.ReadULong( );
          MinSupportedMajorVersion = stream.ReadUShort( );
          MaxSupportedMajorVersion = stream.ReadUShort( );
        }
        void IBinarySerialize.Write( Stream stream )
        {
          throw new NotImplementedException( );
        }
      }
      [StructLayout( LayoutKind.Sequential )]
      internal struct LUID
      {
        public UInt32 LowPart;
        public Int32 HighPart;
      }
      [StructLayout( LayoutKind.Sequential )]
      internal struct LUID_AND_ATTRIBUTES
      {
        public LUID Luid;
        public UInt32 Attributes;
      }
      internal struct TOKEN_PRIVILEGES
      {
        public UInt32 PrivilegeCount;
        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 1 )]		// !! think we only need one
        public LUID_AND_ATTRIBUTES[ ] Privileges;
      }
      [Flags]
      internal enum EFileAttributes: uint
      {
        /// <summary/>
        None = 0,
        //-->  these are consistent w/ .Net FileAttributes...
        Readonly = 0x00000001,
        Hidden = 0x00000002,
        System = 0x00000004,
        Directory = 0x00000010,
        Archive = 0x00000020,
        Device = 0x00000040,
        Normal = 0x00000080,
        Temporary = 0x00000100,
        SparseFile = 0x00000200,
        ReparsePoint = 0x00000400,
        Compressed = 0x00000800,
        Offline = 0x00001000,
        NotContentIndexed = 0x00002000,
        Encrypted = 0x00004000,
        //--> additional CreateFile call attributes...
        Write_Through = 0x80000000,
        Overlapped = 0x40000000,
        NoBuffering = 0x20000000,
        RandomAccess = 0x10000000,
        SequentialScan = 0x08000000,
        DeleteOnClose = 0x04000000,
        BackupSemantics = 0x02000000,
        PosixSemantics = 0x01000000,
        OpenReparsePoint = 0x00200000,
        OpenNoRecall = 0x00100000,
        FirstPipeInstance = 0x00080000
      }
      /// <summary>Reasons the file changed (from USN journal)</summary>
      [Flags]
      public enum UsnReason: uint
      {
        BASIC_INFO_CHANGE = 0x00008000,
        CLOSE = 0x80000000,
        COMPRESSION_CHANGE = 0x00020000,
        DATA_EXTEND = 0x00000002,
        DATA_OVERWRITE = 0x00000001,
        DATA_TRUNCATION = 0x00000004,
        EA_CHANGE = 0x00000400,
        ENCRYPTION_CHANGE = 0x00040000,
        FILE_CREATE = 0x00000100,
        FILE_DELETE = 0x00000200,
        HARD_LINK_CHANGE = 0x00010000,
        INDEXABLE_CHANGE = 0x00004000,
        NAMED_DATA_EXTEND = 0x00000020,
        NAMED_DATA_OVERWRITE = 0x00000010,
        NAMED_DATA_TRUNCATION = 0x00000040,
        OBJECT_ID_CHANGE = 0x00080000,
        RENAME_NEW_NAME = 0x00002000,
        RENAME_OLD_NAME = 0x00001000,
        REPARSE_POINT_CHANGE = 0x00100000,
        SECURITY_CHANGE = 0x00000800,
        STREAM_CHANGE = 0x00200000,
      
        None = 0x00000000
      }
      internal enum ECreationDisposition: uint
      {
        New = 1,
        CreateAlways = 2,
        OpenExisting = 3,
        OpenAlways = 4,
        TruncateExisting = 5
      }
    }

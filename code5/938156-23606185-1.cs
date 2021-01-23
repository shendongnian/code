    internal class APIWrapper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal sealed class FILETIME
        {
            public int Low;
            public int High;
            public Int64 ToInt64()
            {
                Int64 h = High;
                h = h << 32;
                return h + Low;
            }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal sealed class FindData
        {
            public int fileAttributes;
            public FILETIME CreationTime;
            public FILETIME LastAccessTime;
            public FILETIME LastWriteTime;
            public int FileSizeHigh;
            public int FileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public String fileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public String alternateFileName;
        }
        internal sealed class SafeFindHandle : Microsoft.Win32.SafeHandles.SafeHandleMinusOneIsInvalid
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public SafeFindHandle()
                : base(true)
            {
            }
            /// <summary>
            /// Release the find handle
            /// </summary>
            /// <returns>true if the handle was released</returns>
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            protected override bool ReleaseHandle()
            {
                return SafeNativeMethods.FindClose(handle);
            }
        }
        internal enum SearchOptions
        {
            NameMatch,
            LimitToDirectories,
            LimitToDevices
        }
        [SecurityPermissionAttribute(SecurityAction.Assert, UnmanagedCode = true)]
        internal static class SafeNativeMethods
        {
            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern SafeFindHandle FindFirstFile(String fileName, [In, Out] FindData findFileData);
            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern SafeFindHandle FindFirstFileEx(
                String fileName,                    //__in        LPCTSTR lpFileName,
                [In] int infoLevel,                 //__in        FINDEX_INFO_LEVELS fInfoLevelId,
                [In, Out] FindData findFileData,    //__out       LPVOID lpFindFileData,
                [In, Out] SearchOptions SerchOps,             //__in        FINDEX_SEARCH_OPS fSearchOp,
                [In] int SearchFilter,              //__reserved  LPVOID lpSearchFilter,
                [In] int AdditionalFlags);          //__in        DWORD dwAdditionalFlags
            [DllImport("kernel32", CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FindNextFile(SafeFindHandle hFindFile, [In, Out] FindData lpFindFileData);
            [DllImport("kernel32", CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FindClose(IntPtr hFindFile);
        }
    }

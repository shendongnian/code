    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using Microsoft.Win32.SafeHandles;
    namespace Demo
    {
        public class Program
        {
            private void run()
            {
                string root = "C:\\";
                foreach (var folder in FolderEnumerator.EnumerateFoldersRecursively(root))
                    Console.WriteLine(folder);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
        public static class FolderEnumerator
        {
            public static IEnumerable<string> EnumerateFoldersRecursively(string root)
            {
                foreach (var folder in EnumerateFolders(root))
                {
                    yield return folder;
                    foreach (var subfolder in EnumerateFoldersRecursively(folder))
                        yield return subfolder;
                }
            }
            public static IEnumerable<string> EnumerateFolders(string root)
            {
                WIN32_FIND_DATA findData;
                string spec = Path.Combine(root, "*");
                using (SafeFindHandle findHandle = FindFirstFile(spec, out findData))
                {
                    if (!findHandle.IsInvalid)
                    {
                        do
                        {
                            if ((findData.cFileName != ".") && (findData.cFileName != ".."))  // Ignore special "." and ".." folders.
                            {
                                if ((findData.dwFileAttributes & FileAttributes.Directory) != 0)
                                {
                                    yield return Path.Combine(root, findData.cFileName);
                                }
                            }
                        }
                        while (FindNextFile(findHandle, out findData));
                    }
                    else
                    {
                        Debug.WriteLine("Cannot find files in " + spec, "Dmr.Common.IO.FileSystem.FolderContents()");
                    }
                }
            }
            internal sealed class SafeFindHandle: SafeHandleZeroOrMinusOneIsInvalid
            {
                [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
                public SafeFindHandle(): base(true)
                {
                }
                protected override bool ReleaseHandle()
                {
                    if (!IsInvalid && !IsClosed)
                    {
                        return FindClose(this);
                    }
                    return (IsInvalid || IsClosed);
                }
                protected override void Dispose(bool disposing)
                {
                    if (!IsInvalid && !IsClosed)
                    {
                        FindClose(this);
                    }
                    base.Dispose(disposing);
                }
            }
            [StructLayout(LayoutKind.Sequential)]
            internal struct FILETIME
            {
                public uint dwLowDateTime;
                public uint dwHighDateTime;
                public long ToLong()
                {
                    return dwLowDateTime + ((long)dwHighDateTime) << 32;
                }
            };
            [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
        
            internal struct WIN32_FIND_DATA
            {
                public FileAttributes dwFileAttributes;
                public FILETIME       ftCreationTime;
                public FILETIME       ftLastAccessTime;
                public FILETIME       ftLastWriteTime;
                public int            nFileSizeHigh;
                public int            nFileSizeLow;
                public int            dwReserved0;
                public int            dwReserved1;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAX_PATH)]
                public string cFileName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAX_ALTERNATE)]
                public string cAlternate;
            }
            [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Unicode)]
            private static extern SafeFindHandle FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);
            [DllImport("kernel32.dll", SetLastError=true, CharSet=CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool FindNextFile(SafeHandle hFindFile, out WIN32_FIND_DATA lpFindFileData);
            [DllImport("kernel32.dll", SetLastError=true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool FindClose(SafeHandle hFindFile);
            private const int MAX_PATH = 260;
            private const int MAX_ALTERNATE = 14;
        }
    }

    $fu = @"
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    public class FileUtility
    {
        private struct FILE_BASIC_INFO
        {
            [MarshalAs(UnmanagedType.I8)]
            public Int64 CreationTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 LastAccessTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 LastWriteTime;
            [MarshalAs(UnmanagedType.I8)]
            public Int64 ChangeTime;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 FileAttributes;
        }
        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool SetFileInformationByHandle(
            IntPtr hFile,
            int FileInformationClass,
            FILE_BASIC_INFO lpFileInformation,
            Int32 dwBufferSize);
        public void SetFileChangeTime()
        {
            using (FileStream fs = new FileStream(@"c:\path\to\file", FileMode.Open))
            {
                FILE_BASIC_INFO fileInfo = new FILE_BASIC_INFO();
                fileInfo.ChangeTime = 943044610000000;
                SetFileInformationByHandle(
                    fs.Handle,
                    0,  // the same as FILE_INFO_BY_HANDLE_CLASS.FileBasicInfo
                    fileInfo,
                    Marshal.SizeOf(fileInfo));
            }
        }
    }
    "@
    Add-Type -TypeDefinition $fu -IgnoreWarnings
    $f = New-Object -TypeName FileUtility
    $f.SetFileChangeTime()

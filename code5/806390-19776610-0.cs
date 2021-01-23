    [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)] 
    private static extern SafeFileHandle CreateFile(
    string name, FileAccess access, FileShare share,
    IntPtr security,
    FileMode mode, FileAttributes flags,
    IntPtr template);
        public static void Main()
        {
            // Opens the ":Zone.Identifier" alternate data stream that blocks the file
            using (SafeFileHandle handle = CreateFile(@"\\?\C:\Temp\a.txt:Zone.Identifier", FileAccess.ReadWrite, FileShare.None, IntPtr.Zero, FileMode.OpenOrCreate, FileAttributes.Normal, IntPtr.Zero))
            {
                // Here add test of CreateFile return code
                // Then :
                using (FileStream fs = new FileStream(handle, FileAccess.ReadWrite))
                {
                    // ZoneId="3" means "Internet", see: System.Security.SecurityZone
                    byte[] buffer = Encoding.ASCII.GetBytes(@"[ZoneTransfer]
    ZoneId=3");
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Flush();
                }
            }

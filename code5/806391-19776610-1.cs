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
                using (StreamWriter writer = new StreamWriter(new FileStream(handle, FileAccess.ReadWrite), Encoding.ASCII))
                {
                    writer.WriteLine("[ZoneTransfer]");
                    writer.WriteLine("ZoneId=3");
                }
            }

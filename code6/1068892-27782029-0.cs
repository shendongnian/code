    public struct FILE_TIME
    {
        public FILE_TIME(long fileTime)
        {
            ftTimeLow = (uint)fileTime;
            ftTimeHigh = (uint)(fileTime >> 32);
        }
        public long ToTicks()
        {
            return ((long)ftTimeHigh << 32) + ftTimeLow;
        }
        public uint ftTimeLow;
        public uint ftTimeHigh;
    }
	internal const String KERNEL32 = "kernel32.dll";
	[DllImport(KERNEL32, SetLastError = true)]
	public unsafe static extern bool SetFileTime(SafeFileHandle hFile, FILE_TIME* creationTime,
				FILE_TIME* lastAccessTime, FILE_TIME* lastWriteTime);
	public static void SetLastAccessTime(string fullPath, DateTime lastAccess, Action afterLock)
	{
		long lastAccessTimeUtc = lastAccess.ToUniversalTime().ToFileTimeUtc();
		using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite, 1))
		{
			SafeFileHandle handle = fs.SafeFileHandle;
			if (!handle.IsInvalid)
			{
				afterLock();
				FILE_TIME fileTime = new FILE_TIME(lastAccessTimeUtc);
				bool r = SetFileTime(handle, null, &fileTime, null);
				if (!r)
				{
					
				}
			}
		}
	}

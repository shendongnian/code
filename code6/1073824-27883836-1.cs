    private static void Copy(string oldFile, string newFile, CancellationToken cancellationToken)
    {
        bool cancel = false;
        using (cancellationToken.Register(() => cancel = true))
        {
            if (!CopyFileEx(oldFile, newFile, null, IntPtr.Zero, ref cancel, CopyFileFlags.COPY_FILE_RESTARTABLE))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            GC.KeepAlive(cancel);
        }
    }

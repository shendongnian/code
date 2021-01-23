    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
        CopyProgressRoutine lpProgressRoutine, IntPtr lpData, ref bool pbCancel,
        CopyFileFlags dwCopyFlags);
    private const int CopyCanceledErrorCode = 1235;
    private static void Copy(string oldFile, string newFile, CancellationToken cancellationToken)
    {
        var cancel = false;
        CopyProgressRoutine callback =
            (size, transferred, streamSize, bytesTransferred, number, reason, file, destinationFile, data) =>
            {
                if (cancellationToken.IsCancellationRequested)
                    return CopyProgressResult.PROGRESS_CANCEL;
                else
                    return CopyProgressResult.PROGRESS_CONTINUE;
            };
        if (!CopyFileEx(oldFile, newFile, callback, IntPtr.Zero, ref cancel, CopyFileFlags.COPY_FILE_RESTARTABLE))
        {
            var error = Marshal.GetLastWin32Error();
            if (error == CopyCanceledErrorCode)
                throw new OperationCanceledException(cancellationToken);
                    //Throws the more .NET friendly OperationCanceledException
            throw new Win32Exception(error);
        }
        //This prevents the callback delegate from getting GC'ed before the native call is done with it.
        GC.KeepAlive(callback);
    }

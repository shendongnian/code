    public override bool GetOverlappedResult(SafeHandle interfaceHandle, IntPtr pOverlapped, out int numberOfBytesTransferred, bool wait)
    {
        // To prevent ObjectDisposedException check if SafeHandle's been closed
        if (!interfaceHandle.IsClosed)
            return Kernel32.GetOverlappedResult(interfaceHandle, pOverlapped, out numberOfBytesTransferred, wait);
        else
        {
            numberOfBytesTransferred = 0;
            return true;
        }
    }

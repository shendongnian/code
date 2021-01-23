    try
    {
        Marshal.ReleaseComObject(ie);
    }
    catch (COMException ex)
    {
        // I'm getting 0x80010108, rather than 0x800706BA
        // The object invoked has disconnected from its clients. (Exception from HRESULT: 0x80010108 (RPC_E_DISCONNECTED)
        if ((uint)ex.ErrorCode != 0x80010108) 
            throw;
    }

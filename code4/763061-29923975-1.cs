    Metafile emf = null;
    if (OpenClipboard(IntPtr.Zero))
    {
        if (IsClipboardFormatAvailable(CF_ENHMETAFILE))
        {
            var ptr = GetClipboardData(CF_ENHMETAFILE);
            if (!ptr.Equals(IntPtr.Zero))
                emf = new Metafile(ptr, true);
        }
        // You must close ir, or it will be locked
        CloseClipboard();
    }

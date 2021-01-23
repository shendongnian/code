    public FontFamily GetFontFamily(byte[] bytes)
    {
        FontFamily fontFamily = null;
    
        var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    
        try
        {
            var ptr = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, 0);
            var fontCollection = new PrivateFontCollection();
            fontCollection.AddMemoryFont(ptr, bytes.Length);
            fontFamily = fontCollection.Families[0];
        }
        finally
        {
            // don't forget to unpin the array!
            handle.Free();
        }
    
        return fontFamily;
    }

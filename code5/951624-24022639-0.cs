    private PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
    
    public FontFamily GetFontFamilyByName(string name)
    {
        return _privateFontCollection.Families.FirstOrDefault(x => x.Name == name);
    }
    
    
    public void AddFont(string fullFileName)
    {
        var fontBytes = File.ReadAllBytes(fullFileName);
        var handle = GCHandle.Alloc(fontBytes, GCHandleType.Pinned);
        IntPtr pointer = handle.AddrOfPinnedObject();
        try
        {
            _privateFontCollection.AddMemoryFont(pointer, fontBytes.Length);
        }
        finally
        {
            handle.Free();
        }
    }

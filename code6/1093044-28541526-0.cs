    public Stream OpenFile()
    { 
        string filename = FileNamesInternal[0];
        if (filename == null || (filename.Length == 0))
            throw new ArgumentNullException("FileName");
        Stream s = null; 
        new FileIOPermission(FileIOPermissionAccess.Read, IntSecurity.UnsafeGetFullPath(filename)).Assert();
        try
        {
            s = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read); 
        }
        finally 
        { 
            CodeAccessPermission.RevertAssert();
        } 
        return s;
    }

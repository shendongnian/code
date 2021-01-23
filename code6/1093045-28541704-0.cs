    public Stream OpenFile()
    {
    	IntSecurity.FileDialogOpenFile.Demand();
    	string str = this.FileNamesInternal[0];
    	
    	if (str == null || str.Length == 0)
    		throw new ArgumentNullException("FileName");
    		
    	new FileIOPermission(FileIOPermissionAccess.Read, IntSecurity.UnsafeGetFullPath(str)).Assert();
    	
    	try
    	{
    		return (Stream) new FileStream(str, FileMode.Open, FileAccess.Read, FileShare.Read);
    	}
    	finally
    	{
    		CodeAccessPermission.RevertAssert();
    	}
    }

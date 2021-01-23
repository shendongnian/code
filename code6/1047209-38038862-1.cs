	void	scan_dir(string path)
	{
		// Exclude some directories according to their attributes
		string[] files = null;
		string skipReason = null;
		var dirInfo = new DirectoryInfo( path );
		var isroot = dirInfo.Root.FullName.Equals( dirInfo.FullName );
		if (	// as root dirs (e.g. "C:\") apparently have the system + hidden flags set, we must check whether it's a root dir, if it is, we do NOT skip it even though those attributes are present
				(dirInfo.Attributes.HasFlag( FileAttributes.System ) && !isroot)	// We must not access such folders/files, or this crashes with UnauthorizedAccessException on folders like $RECYCLE.BIN
			)
		{	skipReason = "system file/folder, no access";
		}
		if ( null == skipReason )
		{	try
			{	files = Directory.GetFiles( path );
			}
			catch (UnauthorizedAccessException ex)
			{	skipReason = ex.Message;
			}
			catch (PathTooLongException ex)
			{	skipReason = ex.Message;
			}
		}
		if (null != skipReason)
		{	// perhaps do some error logging, stating skipReason
			return; // we skip this directory
		}
		foreach (var f in files)
		{	var fileAttribs = new FileInfo( f ).Attributes;
			// do stuff with file if the attributes are to your liking
		}
		try
		{	var dirs = Directory.GetDirectories( path );
			foreach (var d in dirs)
			{	scan_dir( d ); // recursive call
			}
		}
		catch (PathTooLongException ex)
		{	Trace.WriteLine(ex.Message);
		}
	}

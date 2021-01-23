    using ( ZipInputStream s = new ZipInputStream ( File.OpenRead ( strSourcePath ) ) )
    {  
    	ZipEntry theEntry;
    	while ( ( theEntry = s.NextEntry ) != null )
    	{
    		string directoryName = Path.GetDirectoryName ( theEntry.Name );
    		string fileName = Path.GetFileName ( theEntry.Name );
    		directoryName = Path.Combine ( strDestFolderPath , directoryName );
    		if ( directoryName.Length > 0 )
    		{
    			Directory.CreateDirectory ( directoryName );
    		}
    		if ( fileName != String.Empty )
    		{
    			using ( FileStream streamWriter = File.Create ( Path.Combine ( strDestFolderPath , theEntry.Name ) ) )
    			{
    				int size = 2048;
    				byte [] data = new byte[size];
    				while ( true )
    				{
    					size = s.Read ( data , 0 , data.Length );
    					if ( size > 0 )
    					{
    						streamWriter.Write ( data , 0 , size );
    					}
    					else
    					{
    						break;
    					}
    				}
    			}
    		}
    	} 
    }

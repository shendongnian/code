    using System.IO;
    
    class Foo
    {
    
    	public method Bla()
    	{
    		DirectoryInfo dir;
    		List<FileInfo> lstFiles;
    		string pattern ;
    		string line ;
    		pattern = "OfficeFile.extension" ;
    		dir = new DirectoryInfo("PATH_TO_TRAKING_FOLDER");
    
    		lstFiles = new List<FileInfo>(dir.EnumerateFiles(pattern, SearchOption.AllDirectories).OrderBy(x => x.LastWriteTime) ;
    
    		foreach(FileInfo fi in lstFiles)
    		{
    			line = Strin.format("{0}:{1}", fi.Name,fi.LastWriteTime) ;
    			Console.WriteLine(line) ;
    		}
    	}
    }

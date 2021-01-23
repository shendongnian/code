    using System.IO;
    
    class Foo
    {
    
    	public method Bla()
    	{
    		DirectoryInfo dir;
    		List<FileInfo> lstFiles;
    		string pattern ;
    		string line ;
                //pattern can be something like "Letter.doc" or "Worksheet.xls"
    		pattern = "OfficeFile.extension" ;
                //is the base folder that can contains the different versions of the word/excel files that you are tracking
    		dir = new DirectoryInfo("PATH_TO_TRAKING_FOLDER");
    
    		lstFiles = new List<FileInfo>(dir.EnumerateFiles(pattern, SearchOption.AllDirectories).OrderBy(x => x.LastWriteTime) ;
    
    		foreach(FileInfo fi in lstFiles)
    		{
    			line = Strin.format("{0}:{1}", fi.Name,fi.LastWriteTime) ;
    			Console.WriteLine(line) ;
    		}
    	}
    }

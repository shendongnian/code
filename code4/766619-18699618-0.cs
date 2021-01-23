	//Keep in a list of strings with FileA contents 
	List<string> linesOfFileA = new List<string>();
	string line ;
	
	using (StreamReader sr = new StreamReader(pathToFileA)) 
	{
		//read each line of fileA
		line = sr.ReadLine();
		while(line != null)
		{
			linesOfFileA.Add(line) ;
			line = sr.ReadLine();
		}
	}
	//Now read the contents of FileB
	
	string fileWithoutExtension ;
	int posOfExtension ;
	using (StreamReader srB = new StreamReader(pathToFileB)) 
	{
		//read each line of fileB
		line = sr.ReadLine();
		while(line != null)
		{
			posOfExtension = line.LastIndexOf(".");
			
			if(posOfExtension < 0)
			{
				fileWithoutExtension = line ;
			}				
			else
			{
				fileWithoutExtension = line.Substring(0,posOfExtension) ;
			}
			
            //Check to see if the FileA contains file but without Extension
			if(linesOfFileA.Contains(fileWithoutExtension))
			{
				//Store into another list / or execute here
			}
			line = sr.ReadLine();
		}
	}

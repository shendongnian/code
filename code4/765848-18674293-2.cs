    List<string> newFile = new List<string>();
    bool isMatched = false;
    if (File.Exists("CardResources.ygodc"))
    {  
        string[] originalFile = File.ReadAllLines("CardResources.ygodc");
        
        for (int count = 0; count < originalFile.Length; count++)
        {
            string[] split = originalFile[count].Split('|');
            string title = split[0];
            string times = split[1];
            if (title == cardTitle)
    		{
                newFile.Add(string.Format(
                               "{0}|{1}",
                               title, nudTimes.Value + int.Parse(times)));
    	        isMatched =true;
    	    }
            else
                newFile.Add(string.Format(
                                "{0}|{1}", 
                                title, times));
         }
    	 
    }
    if (!isMatched)
    {
        newFile.Add(string.Format(
                               "{0}|{1}", 
                                cardTitle, nudTimes.Value));
    }
    
    using (StreamWriter sw = new StreamWriter("CardResources.ygodc"))
    {
         foreach (string line in newFile)
         {
             sw.WriteLine(line);
         }
    }

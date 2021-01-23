    List<string> newFile = new List<string>();
    if (!File.Exists("CardResources.ygodc"))
    {
         newFile.Add(string.Format(
                                    "{0}|{1}", 
                                    cardTitle, nudTimes.Value));
    }
    else
    {  
        string[] originalFile; 
        originalFile = File.ReadAllLines("CardResources.ygodc")
        for (int count = 0; count < originalFile.Length; count++)
        {
            string[] split = originalFile[count].Split('|');
            string title = split[0];
            string times = split[1];
            if (title == cardTitle)
                newFile.Add(string.Format(
                               "{0}|{1}", 
                                title, nudTimes.Value + int.Parse(times)));
            else
                newFile.Add(string.Format(
                                "{0}|{1}", 
                                cardTitle, nudTimes.Value));
         }
         
    }
    using (StreamWriter sw = new StreamWriter("CardResources.ygodc", true))
    {
         foreach (string line in newFile)
         {
             sw.WriteLine(line);
         }
    }

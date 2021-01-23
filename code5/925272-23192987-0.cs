    public string MatchedName(string input)
    {
        string nameMatch = null;
        string[] matchList = null;
        const string matchFile = @"C:\matchedfile.txt";
        using (StreamReader r = new StreamReader(matchFile))
        {
           string matchContent = "";
           while ((matchContent = r.ReadLine()) != null)
           {    
               matchList = matchContent.Split(',');
               foreach(string name in matchList)
               {
                    if (String.Equals(RemoveCharTab(input), RemoveCharTab(name)))
                    {
                         nameMatch = name;
                         break;
                    }
                    else
                    {
                         continue;
                    }
               }
               if(string.IsNullOrEmpty(nameMatch) == false)
                  break;
               else
                  continue;
           } //end of While
        }
        if (string.IsNullOrEmpty(nameMatch) == true)
        {
            return input;
        }
        else
        {
            return nameMatch;
        }
    }

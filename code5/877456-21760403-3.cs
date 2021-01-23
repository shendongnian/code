    // key: line index, value: sent line 
    private Dictionary<int, string> sent = new Dictionary<int, string>();
    
    private void PostMessage()
    {
       for (int i = 0; i < ScrollLabel._lines.Length; i++)
        {
            var line = ScrollLabel._lines[i];
            if(sent.ContainsKey(i) && sent[i] == line) continue;
                
            sent[i] = line;
                
            if (WordsList.Any(line.Contains))                           
              PostFacebookWall(LongaccessToken, line + Environment.NewLine + Environment.NewLine 
                                                     + "נשלח באופן אוטומטי כניסיון דרך תוכנה");
        }
    }

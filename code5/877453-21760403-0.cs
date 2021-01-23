    // key: line index, value: line hash code
    private Dictionary<int, int> hashes = new Dictionary<int, int>();
    
    private void PostMessage()
    {
       for (int i = 0; i < ScrollLabel._lines.Length; i++)
        {
            var line = ScrollLabel._lines[i];
            if(!hashes.ContainsKey(i)) hashes[i] = line.GetHashCode();
            else if(hashes[i] == line.GetHashCode()) continue;
                
            hashes[i] = line.GetHashCode();
                
            if (WordsList.Any(line)))
            {
                lineToPost = ScrollLabel._lines[i];
                PostFacebookWall(LongaccessToken, lineToPost + Environment.NewLine + Environment.NewLine + "נשלח באופן אוטומטי כניסיון דרך תוכנה");
            }
            
        }
    }

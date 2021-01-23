    string[] TheFileAsAnArray = ReadFileEntries(path);
    Dictionary<string, string[]> myDict = new Dictionary<string, string[]>()
    string key = "";
    List<string> values = new List<string>();
    for(int i = 0; i <= TheFileAsAnArray.Length; i++)
    {
        
        if(String.isNullOrEmpty(TheFileAsAnArray[i].Trim()))
        {
              myDict.Add(key, values.ToArray());
              key = String.Empty;
              values = new List<string>();
                
        }
        else
        {
            if(key == String.Empty)
                key = TheFileAsAnArray[i];
            else
                values.Add(TheFileAsAnArray[i]);
        }
    }

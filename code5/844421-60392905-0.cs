        List<string> searchitem = new List<string>();
        string[] arrayStrings = {
           "Welcome to SanJose",
           "Welcome to San Fancisco","Welcome to New York",
           "Welcome to Orlando", "Welcome to San Martin",
           "This string has Welcome to San in the middle of it"
        };
       string searchkey = "Welcome to San";
       for (int i = 0; i < arrayStrings.Length; i++)
       {
        if (arrayStrings[i].Contains(searchkey))//checking whether the searchkey contains in the string array
        {
         searchitem.Add(arrayStrings[i]);//adding the matching item to the list 
        }
       string searchresult = string.Join(Environment.NewLine, searchitem);

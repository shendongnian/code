    string test = "Only 'together' can we turn him to the 'dark side' of the Force";
    string[] separated = test.Split('\'');
                
    string result = "";
    
    for (int i = 0; i < separated.Length; i++)
    {
        string str = separated[i];
        str = str.Trim();   //trim the tailing spaces
    
        if (i % 2 == 0 || str.Contains("dark")) // you can expand your condition
        {
           result += str+" ";  // add space after each added string
        }
    }
    result = result.Trim(); //trim the tailing space again

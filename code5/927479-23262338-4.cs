    string[] SplitWithLimit(ref string test, int limit)
    {
        int count=0;
        int pos=-1;
        // Try to find the position of the # at the limit count
        while((pos = test.IndexOf('#', pos+1)) != -1)
        {
            count++;
            if(count == limit)
                break;
        }
        
        string toSplit;
        if(pos != -1)
        {
            // Take the left part of the string to be splitted
            // till the position of the char at limit boundary
            toSplit = test.Substring(0, pos);
            test = test.Substring(pos+1);
        }
        else
        {
            // If there are less # than required, take all the string
            toSplit = test;
            test = "";
        }
        // Now split only the required part   
        string[] parts = toSplit.Split(new char[] {'#'}, StringSplitOptions.RemoveEmptyEntries);
        return parts;
    }

    string Merge(string sep1, string sep2, params string[] items)
    {
        string result = "";
    
        for(int i = 0; i < items.Length - 1; i++)
        {
            result += items[i] + (i % 2 == 0 ? sep1 : sep2);
        }
        //add the last item
        result += items[items.Length - 1];
    
        return result;
    }

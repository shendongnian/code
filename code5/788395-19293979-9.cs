    List<int> GetAllIndices(string input, string search)
    {
        List<int> result = new List<int>();
        
        int index = input.IndexOf(search);
        while(index != -1)
        {
            result.Add(index);
            index++;//increment to avoid matching the same index again
            if(index >= input.Length)//check if index is greater than string (causes exception)
                break;
            index = input.IndexOf(search, index);
        }
        return result;
    }

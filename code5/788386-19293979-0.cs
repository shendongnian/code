    List<int> GetAllIndices(string s, char c)
    {
        List<int> result = new List<int>();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == c)
            {
                result.Add(i);
            }
        }
        return result;
    }

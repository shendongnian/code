    public string InsertSpaces(string s)
    {
        char[] result = new char[s.Length + (s.Length / 4)];
    
        for (int i = 0, target = 0; i < s.Length; i++)
        {
            result[target++] = s[i];
            if (i & 3 == 3)
                result[target++] = ' ';
        }
        return new string(result);
    }

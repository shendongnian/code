    private void addToRanges(string key, int value)
    {
        if(ageRanges.ContainsKey(key))
        {
            ageRanges[key] += value;
        }
        else
        {
            ageRanges.Add(key, value);
        }
    }

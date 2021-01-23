    public  String[] GetAllDateTimePatterns()
    {
        List<String> results = new List<String>(DEFAULT_ALL_DATETIMES_SIZE);
 
        for (int i = 0; i < DateTimeFormat.allStandardFormats.Length; i++)
        {
            String[] strings = GetAllDateTimePatterns(DateTimeFormat.allStandardFormats[i]);
            for (int j = 0; j < strings.Length; j++)
            {
                results.Add(strings[j]);
            }
        }
        return results.ToArray();
    }

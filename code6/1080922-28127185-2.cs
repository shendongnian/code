    private void LoadReferenceMap(string FileName)
    {
        List<int> ArrayMapValues = new List<int>();
    
        if (File.Exists(FileName))
        {
            foreach(string line in File.ReadLines(FileName))
            {
                var lineMap = line.ToCharArray()
                                  .Select(x => Convert.ToInt32(x.ToString()));
                ArrayMapValues.AddRange(lineMap);
            }
            level.SetFieldMap(ArrayMapValues);
        }
    }

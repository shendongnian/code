    public Dictionary<string, int[]> GetArraysFromFile(string path)
    {
        Dictionary<string, int[]> arrays = new Dictionary<string, int[]>();
        string[] lines = System.IO.File.ReadAllLines(path);
        foreach(var line in lines)
        {
            string[] splitLine = line.Split(' ');
            List<int> integers = new List<int>();
            foreach(string part in splitLine)
            {
                int result;
                if(int.TryParse(part, out result))
                {
                    integers.Add(result);
                }
            }
            if(integers.Count() > 0)
            {
                arrays.Add(splitLine[0], integers.ToArray());
            }
        }
        return arrays;
    }

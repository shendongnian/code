    private void ReadValues(string path)
    {
        foreach(string line in File.ReadAllLines(path))
        {
            string[] tokens = string.Split(',');
            string key = tokens[0];
            int value = int.Parse(tokens[1]);
            // TODO: check if key does not already exist
            this.tempValues.Add(key, value);
        }
    }

    public int GetNumOfCharsInFile(string filePath)
    {
        int count = 0;
        using (var sr = new StreamReader(filePath))
        {
            while (sr.Read() != -1)
                count++;
        }
        return count;
    }

    public void loadFile(string filename)
    {
        using (FileStream file = File.OpenRead(filename))
        {
            // Do something with file
        }
    }

    private object WRITELOCK = new object();
    private void AppendToFile(string fileName, string textToAppend)
    {
        lock (WRITELOCK)
        {
            File.AppendAllText(fileName, textToAppend);
        }
    }

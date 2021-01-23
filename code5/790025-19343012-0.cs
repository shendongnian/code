    public void savefile(string path)
    {
      //File.Delete(path); you don't need this line
      File.WriteAllText(path, "Hello World");
    }

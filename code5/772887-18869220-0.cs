    [HttpGet]
    public List<File> Get()
    {
        return myFileClass.MyMethodThatReturnsAListOfFiles;
    }
    [HttpGet]
    public File Get(int id)
    {
        return myFileClass.MyMethodThatReturnsASpecificFile(id);
    }

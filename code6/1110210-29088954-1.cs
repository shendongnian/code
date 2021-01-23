    [AcceptVerbs(HttpVerbs.Post)]
    public string GetFile(string[] strings)
    {
        for (int i = 0; i < strings.Length; i++)
        {
            // Do some stuff with string array here.
        }
        Guid token = Guid.NewGuid();
        InMemoryInstances instance = InMemoryInstances.Instance;
        instance.addToken(token.ToString());
        return token.ToString();
    }
    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult GetFile(string token)
    {
        string filename = @"c:\temp\afile.txt";
        InMemoryInstances instance = InMemoryInstances.Instance;
        if (instance.checkToken(token))
        {
            instance.removeToken(token);
            FileStreamResult resultStream = new FileStreamResult(new FileStream(filename, FileMode.Open, FileAccess.Read), "txt/plain");
            resultStream.FileDownloadName = Path.GetFileName(filename);
            return resultStream;
        }
        else
        {
            return View("Index");
        }
            
    }

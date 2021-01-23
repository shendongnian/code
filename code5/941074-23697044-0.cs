    public FileResult GetFile()
    {
    //Read file content into variable.
    string content=File.ReadAllText("filepath");
    byte[] byteArray = Encoding.ASCII.GetBytes(content);
    return File(byteArray, System.Net.Mime.MediaTypeNames.Text.Plain, "ToiletFlush.log");
    }

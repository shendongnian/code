    try
    {
        WebClient client = new WebClient()
        client.DownloadFile(new Uri(@"http://www....com/img.jpg"), path);
    }
    catch (Excepcion ex)
    {
        //Debug here or set the text of some control to ex.Message to see what is causing the problem
    }
    finally
    {
        //dispose client
    }

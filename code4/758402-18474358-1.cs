    try
    {
       page = web.Load(url + Convert.ToString(i + 1) + "/");
    }
    catch (ArgumentException ex)
    {
        //do something about ArgumentException
    }
    catch (System.IO.IOException ex) 
    {
        //do something about IOException
    }

    try
    {
       page = web.Load(url + Convert.ToString(i + 1) + "/");
    }
    catch (System.IO.IOException ex)
    {
      //do something
    }

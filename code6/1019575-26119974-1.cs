    byte[] b;
    try
    {
       b = System.IO.File.ReadAllBytes(filepath);
       //...
    }
    catch(FileNotFoundException e)
    {
       //...
    }

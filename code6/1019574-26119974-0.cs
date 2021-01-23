    byte[] b;
    if (File.Exists(filepath))
    {
       b = System.IO.File.ReadAllBytes(filepath);
       //...
    }
    else
    {
       //...
    }

    Stream strumien;
    StreamReader sr;
    
    try
    {
        sr = irCustomEncoding == 0 ? StreamReader sr = new StreamReader(strumien) : StreamReader sr = new StreamReader(...);
        if (irCustomEncoding == 0)
        {
            srBody = sr.ReadToEnd();
        }
        else
        {
            // use sr
        }
    }
    finally
    {
        strumien.Dispose();
        sr.Dispose();
    }

    string theTime;
    if (int.Parse(DateTime.Now.ToString("HH")) != 0)
    {
        theTime = DateTime.Now.ToString("HH:mm:ss");
    }
    else
    {
        theTime = DateTime.Now.ToString("mm:ss");
    }

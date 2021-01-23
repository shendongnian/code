    if (!File.Exists(name))
    {
        //File.Create(name);
        using(StreamWriter tw = new StreamWriter(name))
        {
            tw.WriteLine("The very first line!");
        }
    }  

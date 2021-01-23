    using (StreamReader r = new StreamReader("filename.ext"))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            if (line.IndexOf("UniqueString") != -1)
            {
               // do stuff
            }
        }
    }

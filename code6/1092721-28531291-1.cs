    using (StreamReader r = new StreamReader("filename.ext"))
    {
        string line, version = "";
        bool nameFound = false;
        while ((line = r.ReadLine()) != null)
        {
            if (nameFound)
            {
                version = line;
                break;
            }
            if (line.IndexOf("UniqueString") != -1)
            {
                nameFound = true;
                // current line has the name
                // the next line will have the version
            }
        }
        if (version != "")
        {
            // version variable contains the product version
        }
        else
        {
            // not found
        }
    }

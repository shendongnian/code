    static public string nextstring(string textfind)
    {
        string result = string.Empty;
        List<string> found = new List<string>();
        string linejd;
        /* ********************************************************
        * Find the line with certain string */
        using (StreamReader efile = new StreamReader(FILENAME))
         // using (efile)
        {
            int counter = 0;
            while ((linejd = efile.ReadLine()) != null
                    && string.IsNullOrWhiteSpace(result))    // Quit the loop once we have a result!
            {
                counter++;
                if (linejd.Contains(textfind))
                {
                    found.Add(linejd);
                    string nextstring = efile.ReadLine();
                    result = nextstring;               }
            }
        }
        return result;
    }

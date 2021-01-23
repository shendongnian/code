    string path = Server.MapPath("~/content/wordlist.txt");
    using (StreamReader word_stream = new StreamReader(path))
    {
        while (!word_stream.EndOfStream)
        {
            string line = word_stream.ReadLine();
            ... put line into DB ...
        }
    }

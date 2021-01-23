    using (var sr = new StreamReader(source))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            if (line == "Section 1-1")
            {
                for (int i = 0; i < 3; i++)
                {
                    sr.ReadLine();
                }
            }
        }
    }

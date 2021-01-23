    public static int getNumberOfPdfPages(string pathDocument)
    {
        using (StreamReader sr = new StreamReader(File.OpenRead(pathDocument)))
        {
            return new Regex(@"/Type\s*/Page[^s]").Matches(sr.ReadToEnd()).Count;
        }
    }

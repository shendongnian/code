    using (StreamReader sr = System.IO.File.OpenText(filepath))
    using (TextWriter tw = new StreamWriter(wp))
    {
        tw.WriteLine(sr.ReadToEnd());
    }

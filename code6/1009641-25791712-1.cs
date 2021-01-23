    var fNames = new[] { "xml1.xml", "xml2.xml" };
    string line;
    using (var writer = new StreamWriter("output.xml"))
    {
        writer.WriteLine("<Data>");
        foreach (var fName in fNames)
        {
            using (var file = new System.IO.StreamReader(fName))
            {
                while ((line = file.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }
            }
        }
        writer.WriteLine("</Data>");
    }

    List<String> names = new List<String>();
    var sb = new StringBuilder()
    //Retrieve names from a separate source.
    
    
            for (int i = 0; i < names.Count; i++ )
            {
                System.Console.WriteLine(names[i].ToString());
                sb.WriteLine(names[i].ToString());
            }
    using (var writer = new StreamWriter(File.OpenWrite(@"C:\names.txt")))
    {
        writer.WriteLine(sb.ToString());
    }

    using (var file = new System.IO.StreamReader(
                      Path.Combine(
                          Path.GetDirectoryName(
                                 Environment.GetCommandLineArgs()[0]),
                         "testfile.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            listBox1.Items.Add(line);
        }
    }

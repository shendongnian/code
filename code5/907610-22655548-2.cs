    string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    string filePath = pathDesktop + "\\mycsvfile.csv";
    if (!File.Exists(filePath))
    {
        File.Create(filePath).Close();
    }
    string delimter = ",";
    List<string[]> output = new List<string[]>();
    
    //flexible part ... add as many object as you want based on your app logic
    output.Add(new string[] {"TEST1","TEST2"});
    output.Add(new string[] {"TEST3","TEST4"});
    int length = output.Count;
    using (System.IO.TextWriter writer = File.CreateText(filePath))
    {
        for (int index = 0; index < length; index++)
        {
            writer.WriteLine(string.Join(delimter, output[index]));
        }
    }

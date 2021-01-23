    var engine = new FileHelperEngine<Test>();
    engine.HeaderText = engine.GetFileHeader();
    string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + ConfigurationManager.AppSettings["MyPath"];
    if (!Directory.Exists(dirPath))
    {
       Directory.CreateDirectory(dirPath);
    }
    //File location, where the .csv goes and gets stored.
    string filePath = Path.Combine(dirPath, "MyTestFile_" + ".csv");
    engine.WriteFile(filePath, testobjs);

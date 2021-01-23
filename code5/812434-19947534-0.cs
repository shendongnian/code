    string[] Files = System.IO.Directory.GetFiles(@"C:\Orders");
    foreach (string _file in Files)
    {
    string fileContent = System.IO.File.ReadAllText(_file);
    //Do something with fileContent
    }

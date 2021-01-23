    static void Main(string[] args)
    {
        Word._Application application = new Word.Application();
        object fileformat = Word.WdSaveFormat.wdFormatXMLDocument;
        DirectoryInfo directory = new DirectoryInfo(@"c:\abc");
        foreach (FileInfo file in directory.GetFiles("*.doc", SearchOption.AllDirectories))
        {
            if (file.Extension.ToLower() == ".doc")
            {
                object filename = file.FullName;
                object newfilename = file.FullName.ToLower().Replace(".doc", ".docx");
                Word._Document document = application.Documents.Open(filename);
     
                document.Convert();
                document.SaveAs(newfilename, fileformat);
                document.Close();
                document = null;
            }
        }
        application.Quit();
        application = null;
    }

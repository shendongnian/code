    string fileToOpen = filePath[0].ToString();
    string tempFile = Path.GetTempFileName();
    if (filePath.Count > 1)
    {
         XDocument merged = new XDocument(new XElement("root"));
         for (int i = 0; i < filePath.Count; i ++)
         {
             XDocument doc = XDocument.Load(filePath[i]);
             merged.Root.Add(XDocument.Load(filePath[i]).Root);
         }
         merged.Save(tempFile);
         fileToOpen = tempFile;
    }
    var application = new Excel.Application();
    object missing = System.Reflection.Missing.Value;
    application.Workbooks.OpenText(
                        fileToOpen,
                        missing,
                        1,
                        missing,
                        Excel.XlTextQualifier.xlTextQualifierNone,
                        missing,
                        missing,
                        missing,
                        true,
                        missing,
                        missing,
                        missing,
                        missing,
                        missing,
                        missing,
                        missing,
                        missing,
                        missing
                        ); 

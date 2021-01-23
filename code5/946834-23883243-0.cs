        Type wordType = Type.GetTypeFromProgID("Word.Application");
        dynamic Word = Activator.CreateInstance(wordType);
        object oMissing = System.Reflection.Missing.Value;
        DirectoryInfo dirInfo = new DirectoryInfo(@"\\server\folder");
        FileInfo wordFile = new FileInfo(fileName);
        Word.Visible = false;
        Word.ScreenUpdating = false;
        Object filename = (Object)wordFile.FullName;
        var doc = Word.Documents.Open(ref filename);
        doc.Activate();
        object outputFileName = wordFile.FullName.Replace(".doc", ".pdf");
    /*in the WdSaveFormat enum, 17 is the value for pdf format*/ 
        object fileFormat = 17;
        doc.SaveAs(ref outputFileName, ref fileFormat);
         
     /in the   WdSaveOptions enum, 0 is for Do not save pending changes.*/
        object saveChanges = 0;
        doc.Close(ref saveChanges);
        doc = null;
        Word.Quit();
        MessageBox.Show("Successfully converted");

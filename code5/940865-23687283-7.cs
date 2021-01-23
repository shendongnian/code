    private void button1_Click(object sender, EventArgs e)
    {
        string docPath = @"C:\Users\<computer name>\Documents\TestItemHelpers"
        string testFile = "TestWordDoc.docx";
        
        Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
        Document document = application.Documents.Open(Path.Combine(docPath,testFile );
        application.ActiveDocument.SaveAs(Path.Combine(docPath,"TestTxt.txt"), WdSaveFormat.wdFormatText, ref noEncodingDialog);
        ((_Application)application).Quit();
        string readText = File.ReadAllText(Path.Combine(docPath,"TestTxt.txt"));
        //do regex here
    }

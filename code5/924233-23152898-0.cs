    var WordApp = new Microsoft.Office.Interop.Word.Application();         
    WordApp.Documents.Add();
    WordApp.Visible = true;         
    Microsoft.Office.Interop.Word.Document doc = WordApp.ActiveDocument;
    doc.InlineShapes.AddPicture("c:\\mypic1.jpeg");
    doc.InlineShapes.AddPicture("c:\\20140203_202325.jpg");            
    doc.SaveAs2("C:\\MyDocument.doc");            
    WordApp.Quit(Type.Missing, Type.Missing, Type.Missing);

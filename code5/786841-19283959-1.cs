         object fileName = Path.Combine(System.Windows.Forms.Application.StartupPath, "document.docx");
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = true };
        Microsoft.Office.Interop.Word.Document aDoc = wordApp.Documents.Open(ref fileName, ReadOnly: false, Visible: true);
        aDoc.Activate();
        FindAndReplace(word, "{id}", "12345");

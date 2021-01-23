            Microsoft.Office.Interop.Word.Application wordApp = null;
            wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;
            Document wordDoc = wordApp.Documents.Open(@"C:\test.docx");
            Bookmark bkm = wordDoc.Bookmarks["name_field"];
            Microsoft.Office.Interop.Word.Range rng = bkm.Range;
            rng.Text = "Adams Laura"; //Get value from any where

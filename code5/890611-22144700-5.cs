        Document CurrDoc;
        //avoid ambiguity so put in missing argument
        object missing = System.Reflection.Missing.Value;
        Microsoft.Office.Interop.Word.Application app;
        private void btnMakeandOpenDoc_Click(object sender, EventArgs e)
        {
            //put in some byte value into the array
            byte[] binary_document = { 112, 132, 32, 33,231,125,87 };
            var tmpFile = @"C:\donkey.doc";
            File.WriteAllBytes(tmpFile, binary_document);
            app = new Microsoft.Office.Interop.Word.Application();
            CurrDoc = app.Documents.Open(@"C:\donkey.doc");
            //main point
            app.Visible = true;
        }
        
        //close the opening doc file also
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            CurrDoc.Close(ref missing, ref missing, ref missing);
            app.Application.Quit(ref missing, ref missing, ref missing);
        }

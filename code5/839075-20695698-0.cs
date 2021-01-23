       String content="";
       private void btnUpload_Click(object sender, EventArgs e)
        {
            string fileName;
            // Show the dialog and get result.
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                fileName = ofd.FileName;
                var application = new Microsoft.Office.Interop.Word.Application();
                //var document = application.Documents.Open(@"D:\ICT.docx");
                 //read all text into content
                content=System.IO.File.ReadAllText(fileName);
                //var document = application.Documents.Open(@fileName);
            }
        }
     private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "fileName";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                 printDoc.PrintPage += new PrintPageEventHandler(pd_PrintPage);            
                 printDoc.Print(); 
            }
        }
     private void pd_PrintPage(object sender, PrintPageEventArgs ev)
     {
       ev.Graphics.DrawString(content,printFont , Brushes.Black,
                       ev.MarginBounds.Left, 0, new StringFormat());
     }

            Document docs = new Document();
            try
            {
                // variable to store file path
                string FilePath = @"C:\Kaustubh_Tupe\WordRepository/docName.docx";
                // create word application
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                // create object of missing value
                object miss = System.Reflection.Missing.Value;
                // create object of selected file path
                object path = FilePath;
                // set file path mode
                object readOnly = false;
                // open Destination                
                docs = word.Documents.Open(ref path, ref miss, ref readOnly,
                    ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss, ref miss);
                //select whole data from active window Destination
                docs.ActiveWindow.Selection.WholeStory();
                // handover the data to cllipboard
                docs.ActiveWindow.Selection.Copy();
                // clipboard create reference of idataobject interface which transfer the data
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return docs;
        }

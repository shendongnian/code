    public PDFWriter(String Path, String FileName) {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            try
            {
                word.Visible = false;
                word.Documents.Open(Path);
                word.ActiveDocument.SaveAs2(FileName + ".pdf", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);
                this.Path = FileName + ".pdf";
            }
            catch (Exception e)
            {
                word.Quit();
                throw new Exception(e.Message);
            }
            finally
            {
                word.Quit();
            }
        }
  

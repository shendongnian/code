    Microsoft.Office.Interop.Word._Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word._Document document = wordApp.Documents.Open(fileName);
    
                fileName = fileName.ToLower().Replace(".doc", ".docx");
                document.Convert();
                document.SaveAs(fileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument);
                document.Close();
                document = null;

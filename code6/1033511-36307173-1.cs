    Microsoft.Office.Interop.Word.Application Objword = new Microsoft.Office.Interop.Word.Application();
    List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
    
    //creating the object of document class  
    Document objdoc = new Document();
    try
    {
        //createting the object of application class  
        //get the uploaded file full path  
        dynamic FilePath = strfilename;
        // the optional (missing) parameter to API  
        dynamic NA = System.Type.Missing;
        //open Word file document 
        objdoc = Objword.Documents.Open
            (ref FilePath, ref NA, ref NA, ref NA, ref NA,
             ref NA, ref NA, ref NA, ref NA,
             ref NA, ref NA, ref NA, ref NA,
             ref NA, ref NA, ref NA);
        //creating the object of string builder class  
        // StringBuilder sb = new StringBuilder();
        for (int Line = 0; Line < objdoc.Paragraphs.Count; Line++)
        {
            string Alignment = objdoc.Paragraphs[Line + 1].Format.Alignment.ToString();
                  
            Microsoft.Office.Interop.Word.Style style2 = objdoc.Paragraphs[Line + 1].Format.get_Style();
            string Filedata = objdoc.Paragraphs[Line + 1].Range.Text.Replace("\r", "~").Replace("\t", "^");
            Microsoft.Office.Interop.Word.Style style = objdoc.Paragraphs[Line + 1].Range.get_Style();
            Microsoft.Office.Interop.Word.Style baseStyle = style.get_BaseStyle();
            string font = style2.Font.Name.ToString();
                   
            string spacing = style2.ParagraphFormat.LineSpacing.ToString();
            string strstyle = style2.Description.ToString();
            data.Add(new KeyValuePair<string, string>(Filedata, strstyle));
        }

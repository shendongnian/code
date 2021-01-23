    //This will return you headers and text below of corrousponding header
        private List<Tuple<string, string>> GetPlainTextByHeaderFromWordDoc(string docname)
        {
            #region for Plain text collection from document
            List<Tuple<string, string>> docPlainTextWithHeaderList = new List<Tuple<string, string>>();
            string headerText = string.Empty;
            string finalTextBelowHeader = string.Empty;
            try
            {
                Document doc = ReadMsWord(docname, objCommonVariables);
                if (doc.Paragraphs.Count > 0)
                {
                    //heading with 1st paragraph
                    foreach (Paragraph paragraph in doc.Paragraphs)
                    {
                        Style style = paragraph.get_Style() as Style;
                        headerText = string.Empty;
                        finalTextBelowHeader = string.Empty;
                        if (style.NameLocal == "Heading 1")
                        {
                        headerText = paragraph.Range.Text.TrimStart().TrimEnd();
                            //reading 1st paragraph of each section
                            for (int i = 0; i < doc.Paragraphs.Count; i++)
                            {
                                if (paragraph.Next(i) != null)
                                {
                                    Style yle = paragraph.Next(i).get_Style() as Style;
                                    if (yle.NameLocal != "Heading 1")
                                    {
                                        finalTextBelowHeader += paragraph.Next(i).Range.Text.ToString();
                                    }
                                    else if (yle.NameLocal == "Heading 1" && !headerText.Contains(paragraph.Next(i).Range.Text.ToString()))
                                    {
                                        break;
                                    }
                                }
                            }
                            string header = Regex.Replace(headerText, "[^a-zA-Z\\s]", string.Empty).TrimStart().TrimEnd();
                            string belowText = Regex.Replace(finalTextBelowHeader, @"\s+", String.Empty);
                            belowText = belowText.Trim().Replace("\a", string.Empty);
                            docPlainTextWithHeaderList.Add(new Tuple<string, string>(header, belowText));
                        }
                    }
                }
                else
                {
                 //error msg: unable to read
                }
                doc.Close(Type.Missing, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
     }
      //This will read and return word document
      private Document ReadMsWord(string docName)
         {
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
       

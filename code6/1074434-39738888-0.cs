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

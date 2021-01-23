        using (DocX doc = DocX.Load("d:\\Sample.docx"))
           {     
               for (int i = 0; i < doc.Paragraphs.Count; i++)
               {                      
                    foreach (var item in doc.Paragraphs[i])
                    {
                        if (doc.Paragraphs[i] is Paragraph)
                        {
                            Paragraph sen = doc.Paragraphs[i] as Paragraph;
                            Formatting form = new Formatting();
                            form.Highlight = Highlight.yellow;
                            form.Bold = true;
                            sen.ReplaceText(searchText, searchText, false,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase,
                            form, null, MatchFormattingOptions.ExactMatch);
                        }
                    }
               }
            doc.Save();
        }

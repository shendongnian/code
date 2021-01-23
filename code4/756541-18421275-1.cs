                 doc = page.Documents.Open(Application.StartupPath + "\\old\\" + fi);
                if (doc != null)
                {
                    for (int x = 1; x <= doc.Words.Count - 1; x++)
                    {
                            if (doc.Words[x].Underline != word.WdUnderline.wdUnderlineNone && doc.Words[x].Underline != word.WdUnderline.wdUnderlineDouble)
                                doc.Words[x].Font = new word.Font() { Name = "Times New Roman", Bold = 4, Size = 12 };
                            else
                                doc.Words[x].Font = new word.Font() { Name = "Times New Roman", Size = 8 };
                    }

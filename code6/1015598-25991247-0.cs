    public List<string> getChapterNumbers()
        {
            List<string> chapters = new List<string>();
            foreach (Word.Paragraph p in currentDocument.Paragraphs)
            { 
                string style = p.get_Style();
                if (style.Equals("Heading 1"))
                {
                    var chapter = p.Range.ListFormat.ListString;
                    chapters.Add(chapter);
                }
                if (style.Equals("Heading 2"))
                {
                    var chapter = p.Range.ListFormat.ListString;
                    chapters.Add(chapter);
                }
            }
            return chapters;
        }

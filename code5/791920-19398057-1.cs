    using Word = Microsoft.Office.Interop.Word;
    
    //...
    foreach (Word.Section s in final.Sections)
    {
        foreach (Word.Revision r in s.Range.Revisions)
        {
                 counter += r.Range.Words.Count;
                 if (r.Type == Word.WdRevisionType.wdRevisionDelete) // Deleted
                    delcnt += r.Range.Words.Count;
                 if (r.Type == Word.WdRevisionType.wdRevisionInsert) // Inserted
                    inscnt += r.Range.Words.Count;
                 if (r.Type == Word.WdRevisionType.wdRevisionProperty) // Formatting (bold,italics)
                    inscnt += r.Range.Words.Count;
        }
    }

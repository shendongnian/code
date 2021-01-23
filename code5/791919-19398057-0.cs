    using Word = Microsoft.Office.Interop.Word;
    
    //...
    foreach (Word.Section s in final.Sections)
    {
        foreach (Word.Revision r in s.Range.Revisions)
        {
                 counter += r.Range.Words.Count;
                 if (r.Type == Word.WdRevisionType.wdRevisionDelete)
                    delcnt += r.Range.Words.Count;
                 if (r.Type == Word.WdRevisionType.wdRevisionInsert)
                    inscnt += r.Range.Words.Count;
        }
    }

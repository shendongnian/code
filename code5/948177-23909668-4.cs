    void FormatText()
    {
       var entries = new List<string>();
       entries.Add("some text here, ");
       entries.Add("some more text here, ");
       entries.Add("and even more text here. ");
       foreach (var entry in entries)
       {
            object newRangeStart = Globals.ThisDocument.Paragraphs[1].Range.End-1;
            Globals.ThisDocument.Paragraphs[1].Range.InsertAfter(entry);
            object newRangeEnd = Globals.ThisDocument.Paragraphs[1].Range.End;
            var newRange = Globals.ThisDocument.Range(ref newRangeStart, ref newRangeEnd);
            if (entry == "some more text here, ")
            {                
                 newRange.Bold = 1;
                 //bookmark this range
                 Microsoft.Office.Tools.Word.Bookmark bmkStart;
                 bmkStart = this.Controls.AddBookmark(newRange, "RangeBookMark");
            }                
            else
                 newRange.Bold = 0;
        }   
    }

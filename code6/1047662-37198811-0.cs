    using Word = Microsoft.Office.Interop.Word;
    Word.Application oWord = new Word.Application();
    Word.Document oTgtDoc = new Word.Document();
    float heightOfPage = oWord.Selection.PageSetup.PageHeight - oWord.Selection.PageSetup.BottomMargin;
    foreach (Word.Paragraph p in oTgtDoc.Paragraphs)
    {
        if (p.Range.End < p.Range.StoryLength)
        {
            int i;
            if (p.Range.Information[Word.WdInformation.wdWithInTable])
            {
                i = oTgtDoc.Range(p.Range.End - 1, p.Range.End - 1).Information[Word.WdInformation.wdVerticalPositionRelativeToPage];
            }
            else
            {
                i = oTgtDoc.Range(p.Range.End, p.Range.End).Information[Word.WdInformation.wdVerticalPositionRelativeToPage];
            }
            if (heightOfPage - i < 0)
            {
                p.Range.Rows[1].AllowBreakAcrossPages = true;
            }
        }
    }

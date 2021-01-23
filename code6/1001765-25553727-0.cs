    Word.Section section = Document.Sections[1];
    var headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
    foreach(Word.Field field in headerRange.Fields)
    {
        if(field.Type == Word.WdFieldType.wdFieldDocProperty
          && field.Code.Text.Contains(myCustomProperty))
        {
            //already has the header
            return;
        }
    }
    headerRange.Collapse(Word.WdCollapseDirection.wdCollapseStart);
    headerRange.InsertParagraphBefore();
    headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
    headerRange.Collapse(Word.WdCollapseDirection.wdCollapseStart);
    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                
    headerRange.Font.Name = this.FontName;
    headerRange.Font.Size = this.FontSize;
    headerRange.Font.Bold = (int)this.IsBold;
    headerRange.Font.Italic = (int)this.IsItalic;
    headerRange.HighlightColorIndex = Word.WdColorIndex.wdYellow;
                    
    var f = (Word.Field)headerRange.Fields.Add(headerRange,
                            Word.WdFieldType.wdFieldDocProperty,
                            myCustomProperty,
                            true);

    Word.Table fTable = footerRange.Tables.Add(footerRange, 1, 3);
    cellRange = fTable.Cell(1, 3).Range;
    cellRange.Collapse(Word.WdCollapseDirection.wdCollapseStart);
    cellRange.Fields.Add(cellRange, Word.WdFieldType.wdFieldDate);
    // this is the important part, set the fontName again on the original Range (don't use cellRange)
    fTable.Cell(1, 3).Range.Font.Name = FontName;

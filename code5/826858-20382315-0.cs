    Word.Range rng=table.Cell(2,2).Range;
    rng.End=rng.End-1;
    rng.Start=rng.End;
    rng.Select();
    app.Selection.Range.Fields.Add(app.Selection.Range,Word.WdFieldType.wdFieldPage,oMissing,oMissing);

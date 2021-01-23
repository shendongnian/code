    for (int k = 0; k < sourceShapeProps.textFrame.TextRange.Runs.Count; k++)
       {
        var run = sourceShapeProps.textFrame.TextRange.get_Runs(k + 1, 1);
        var characters = cell.Shape.TextFrame2.TextRange.get_Characters(run.Start, run.Length);
        characters.Font.Fill.ForeColor.RGB = run.Font.Fill.ForeColor.RGB;
        characters.Font.Bold = run.Font.Bold;
        characters.Font.Italic = run.Font.Italic;
       }

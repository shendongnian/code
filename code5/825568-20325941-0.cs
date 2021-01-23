    if (workSheet.Columns.Name == "校验结果")
    {
        Excel.Range range = workSheet.Cells[i, j] as Excel.Range;
        if (range.Value2.ToString() == "false")
        {
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        }
        else
        {
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
        }
    }

    Excel.FormatCondition fc = (Excel.FormatCondition)fcs.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlEqual, "TRUE", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    fc.Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
    fc.Font.Color = ColorTranslator.ToOle(Color.ForestGreen);
    
    fc = (Excel.FormatCondition)fcs.Add(Excel.XlFormatConditionType.xlCellValue, Excel.XlFormatConditionOperator.xlEqual, "FALSE", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    fc.Interior.Color = ColorTranslator.ToOle(Color.LightSalmon);
    fc.Font.Color = ColorTranslator.ToOle(Color.Red);

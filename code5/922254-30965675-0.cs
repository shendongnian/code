    Microsoft.Office.Interop.Excel.Range range = sheet.get_Range("AK59");
    Microsoft.Office.Interop.Excel.Borders borders = range.Borders;
    Microsoft.Office.Interop.Excel.Border borderTop = borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop];
    Microsoft.Office.Interop.Excel.Border borderLeft = borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft];
    Microsoft.Office.Interop.Excel.Border borderBottom = borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom];
    Microsoft.Office.Interop.Excel.Border borderRight = borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight];
    if (borderBottom.LineStyle == Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous.GetHashCode())
    {
        Console.WriteLine("We have a bottom border line");
    }
    if (borderRight.LineStyle == Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble.GetHashCode())
    {
        Console.WriteLine("We have a double line on the right border");
    }
    if (borderRight.LineStyle != Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone.GetHashCode())
    {
        Console.WriteLine("yeah we have some type of border on the right");
    }

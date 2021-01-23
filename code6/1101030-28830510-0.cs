    var cellContents = cell.GetChildren();
    if (cellContents == null || cellContents.Count < 0) continue;
    foreach (var content in cellContents)
    {
        WpfText wpfText = content as WpfText;
        if (wpfText != null && wpfText.DisplayText.Equals(cellValue, StringComparison.OrdinalIgnoreCase))
        {
               Mouse.DoubleClick(row, new Point(10, 10));
        }
    } 

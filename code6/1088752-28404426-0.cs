    private static ExtractSheetName(string cell)
    {
        var match = Regex.Match(@"(\w[^!]*)|('[^']+)'", cell);
        if (match.Success)
        {
            if (!string.IsNullOrEmpty(match.Groups[1].Value))
                return match.Groups[1].Value;
            if (!string.IsNullOrEmpty(match.Groups[2].Value))
                return match.Groups[2].Values;
        }
        
        return null;
    }
    . . .
    // Using:
    var sheetName = ExptractSheetName(cell);
    string cellRef;
    if (sheetName == null)
        cellRef = cell;
    else
        cellRef = cell.Substring(sheetName.Length + 1);
    

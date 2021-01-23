    private static string ExcelCellReference(int col, int row)
    {
        return ExcelColumnReference(col) + row;
    }
    private const string _columnChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private static string ExcelColumnReference(int col)
    {
        if (col <= 0)
        {
            throw new ArgumentOutOfRangeException("col",
                "Value must be greater than or equal to 1.");
        }
        string columnString = "";
        do
        {
            col--;
            int remainder;
            // Math.DivRem divides by 26 and also gets the remainder.
            col = Math.DivRem(col, 26, out remainder);
            columnString = _columnChars.Substring(remainder, 1) + columnString;
        } while (col > 0);
        return columnString;
    }

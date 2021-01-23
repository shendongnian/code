    var FieldType = GetDataType(sheet.GetCellStyle(rowIndex, columnIndex).FormatCode);
    private string GetDataType(string formatCode)
        {
            if (formatCode.Contains("h:mm") || formatCode.Contains("mm:ss"))
            {
                return "Time";
            }
            else if (formatCode.Contains("[$-409]") || formatCode.Contains("[$-F800]") || formatCode.Contains("m/d"))
            {
                return "Date";
            }
            else if (formatCode.Contains("#,##0.0"))
            {
                return "Currency";
            }
            else if (formatCode.Last() == '%')
            {
                return "Percentage";
            }
            else if (formatCode.IndexOf("0") == 0)
            {
                return "Numeric";
            }
            else
            {
                return "String";
            }
        } 

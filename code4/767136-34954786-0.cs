    public static void SetDelimited(string MyRange) // MyRange = "A:A" or whatever.
    {
        sheet.Range[range].TextToColumns(sheet.get_Range(MyRange , Type.Missing),
        XlTextParsingType.xlDelimited, 
        XlTextQualifier.xlTextQualifierDoubleQuote, 
        true,        // Consecutive Delimiter
        Type.Missing,// Tab
        Type.Missing,// Semicolon
        true,        // Comma
        false,       // Space
        Type.Missing,// Other
        ",",         // Other Char
        Type.Missing,// Field Info
        Type.Missing,// Decimal Separator
        Type.Missing,// Thousands Separator
        Type.Missing);/ Trailing Minus Numbers
    }

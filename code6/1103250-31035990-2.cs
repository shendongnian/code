    private static int? GetColumnIndex(string cellReference)
    {
        if (string.IsNullOrEmpty(cellReference))
        {
            return null;
        }
        //remove digits
        string columnReference = Regex.Replace(cellReference.ToUpper(), @"[\d]", string.Empty);
        int columnNumber = -1;
        int mulitplier = 1;
        //working from the end of the letters take the ASCII code less 64 (so A = 1, B =2...etc)
        //then multiply that number by our multiplier (which starts at 1)
        //multiply our multiplier by 26 as there are 26 letters
        foreach (char c in columnReference.ToCharArray().Reverse())
        {
            columnNumber += mulitplier * ((int)c - 64);
            mulitplier = mulitplier * 26;
        }
        //the result is zero based so return columnnumber + 1 for a 1 based answer
        //this will match Excel's COLUMN function
        return columnNumber + 1;
    }

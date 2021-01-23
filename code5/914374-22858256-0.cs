    public void SearchFunction(string searchtext)
    {
        SupporterId(searchtext);
        ReferenceNumber(searchtext);
        ConsignmentNumber(searchtext);
    }
    private static void SupporterId(string sId)
    {
        var supporterId = Regex.IsMatch(sId, @"^[A-F,S,R][0-9]{3,6}$", RegexOptions.IgnoreCase);
    }
    private static void ReferenceNumber(string refNumber)
    {
        var referenceNumber = Regex.IsMatch(refNumber, @"^[ABN158][0-9]{6,17}$", RegexOptions.IgnoreCase);
    }
    private static void ConsignmentNumber(string conNumber)
    {
        var consignmentNumber = Regex.IsMatch(conNumber, @"&[0-9]{14}$", RegexOptions.IgnoreCase);  
    }

    string s = "";  // In case there is no InnerText.
    try
    {
        s = control.GetProperty("Text").ToString();
    }
    catch ( System.NotSupportedException )
    {
        // No "InnerText" here.
    }

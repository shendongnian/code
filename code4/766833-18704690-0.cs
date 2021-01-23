    public static bool IsValidXml(this string xml)
    {
        try
        {
            XDocument.Parse(xml);
            return true;
        }
        catch
        {
            return false;
        }
    }
Then your code simply looks like  if (mystring.IsValidXml()) {

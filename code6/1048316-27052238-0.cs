    private static string CleanInput(string strIn, string chars)
    {
        // Replace invalid characters with empty strings. 
        try
        {
            string regexString = string.Format(@"[{0}]", chars);
            return Regex.Replace(strIn, regexString, "",
                                    RegexOptions.None, TimeSpan.FromSeconds(1.5));
        }
        // If we timeout when replacing invalid characters,  
        // we should return Empty. 
        catch (RegexMatchTimeoutException)
        {
            return string.Empty;
        }
    }

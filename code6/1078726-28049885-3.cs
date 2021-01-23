    public static bool CheckURLValid(string strURL)
    {
        return Uri.IsWellFormedUriString(strURL, UriKind.RelativeOrAbsolute); ;
    }
 

    public static bool CheckURLValid(string strURL)
    {
        Uri uriResult;
        return Uri.TryCreate(strURL, UriKind.RelativeOrAbsolute, out uriResult);
    }

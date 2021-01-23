    public string RelativeToAbsoluteURLS(string text, string absoluteUrl, string pattern = "src|href")
    {
        if (isHrefRelativeURIPath(text)){
            text = absoluteUrl + "/" + System.Text.RegularExpressions.Regex.Replace("///days/hours.htm", @"^\/+", "");
        }
        return text;
    }
    public bool isHrefRelativeURIPath(string value) {
        if (isLink(value) ||
            value.StartsWith("#") ||
            value.StartsWith("javascript"))
        {
            return false;
        }
        // Others Custom exclusions
        return true;
    }
    public bool isLink(string value) {
        if (String.IsNullOrEmpty(value))
            return false;
        return Uri.IsWellFormedUriString("http://" + value, UriKind.Absolute);
    }

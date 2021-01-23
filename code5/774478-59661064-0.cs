    /// Convertion from HTML color to KML Color
    /// </summary>
    /// <param name="htmlColor"></param>
    /// <returns></returns>
    public string convertColors_HTML_KML(string htmlColor)
    {
        List<string> result = new List<string>(Regex.Split(htmlColor, @"(?<=\G.{2})", RegexOptions.Singleline));
        return "FF" + result[2] + result[1] + result[0];
    }

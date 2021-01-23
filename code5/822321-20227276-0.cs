    [WebMethod]
    public static string GetAvailableTags()
    {
        // Put logic here to return list of tags (i.e. load from database)
        var tags = new[] { "ActionScript", "Scheme" };
        return String.Join(",", tags.Select(x => String.Format("\"{0}\"", x)));
    }

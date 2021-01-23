    [HttpPost]
    public static string TestJquery(string id, string Name)
    {
        return string.Format("Employee Id : {0} Name : {1} ", id, Name);
    }

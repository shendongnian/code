    public static int GetTablePK(string identifier)
    {
        return Convert.ToInt32((from n in xml.Root.Elements("Table")
              select n.Element(indentifier).Value).SingleOrDefault());
    }

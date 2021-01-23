    public string Selector(Excel.Range cell)
    {
        if (cell.Value2 == null)
            return "";
        if (cell.Value2.GetType().ToString() == "System.Double")
            return ((double)cell.Value2).ToString();
        else if (cell.Value2.GetType().ToString() == "System.String")
            return ((string)cell.Value2);
        else if (cell.Value2.GetType().ToString() == "System.Boolean")
            return ((bool)cell.Value2).ToString();
        else
            return "unknown";
    }

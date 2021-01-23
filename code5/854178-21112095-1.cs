    public string getFiltervalue(string filterType, DataTable dt)
    {
        HashSet<string> values = new HashSet<string>();
        foreach(DataRow row in dt.Rows)
        {
             if(row["FilterType"].ToString().Equals(filterType))
             {
                 values.Add("'" + row["FilterType"].ToString() + "'");
             }
        }
    
        return filterType + " in (" + String.Join(",", values.ToArray()) + ")";
    }

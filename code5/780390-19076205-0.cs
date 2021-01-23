    static DataTable ConvertToDatatable(List<Item> list)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("Price");
        dt.Columns.Add("URL");
        foreach (var item in list)
        {
            var row = dt.NewRow();
            row["Name"] = item.Name;
            row["Price"] = Convert.ToString(item.Price);
            row["URL"] = item.URL;
            dt.Rows.Add(row);
        }
        return dt;
    }

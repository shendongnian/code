    private void BindTable()
    {
        DataTable table = GetTableFromDatabase();
        
        var selectedIDs = table.AsEnumerable()
            .Where(r => r.Field<bool>("HasEmail"))
            .Select(r => r.Field<int>("ORG_ID"))
            .ToList();
        if (selectedIDs != null && selectedIDs.Count > 0)
            Session["CheckedIDs"] = selectedIDs;
        OriginalTable.DataSource = table;
        OriginalTable.DataBind();
    }

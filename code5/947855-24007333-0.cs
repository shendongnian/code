        // new table to combine the 3 columns of dtLocation into a one column datatable
        DataTable sortedDt = new DataTable();
        sortedDt.Columns.Add("Location");
        // combining columns
        foreach (DataRow row in dtLocation.Rows)
        {
            sortedDt.Rows.Add(row["Location1"]);
            sortedDt.Rows.Add(row["Location2"]);
            sortedDt.Rows.Add(row["Location3"]);
        }
        // now sort these now that they're all in the same column
        sortedDt.DefaultView.Sort = "Location";
        sortedDt = sortedDt.DefaultView.ToTable(); // should be the new sorted table
         
        // now your original code, but modified to populate the ddl with the new sorted data
        ddlLocation.Items.Clear();
        dtLocation = dataSource.GetFilteredRiskInfo("location");
        ddlLocation.Items.Insert(0, new ListItem("All", "-1"));
        foreach (DataRow row in sortedDt.Rows)
        {
                this.ddlLocation.Items.Add(new ListItem(row["Location"].ToString()));
        }

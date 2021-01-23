    protected void Page_Load(object sender, EventArgs e)
    {
        createTable();
    }
    
    /// <summary>
    /// Creates the table and appends it to the place holder
    /// </summary>
    void createTable()
    {
        //create the table
        Table table = new Table();
        table.ID = "gvd_table";
        table.CssClass = "gvd_table";
    
        //create row 1
        TableRow row = new TableRow();
        row.ID = "gvd_table_row_1";
        row.CssClass = "gvd_table_row";
    
        //get the data
        DataSet dsServiceId;
        dsServiceId = FetchServiceId();
        int countServices;
        countServices = dsServiceId.Tables[0].Rows.Count;
    
        //the row number
        int rows = 1;
    
        //the grids per row
        int gridsPerRow = 4;
    
        //enumerate the row
        for (int i = 0; i < countServices; i++)
        {
            //create our table cell
            TableCell cell = new TableCell();
            cell.ID = string.Format("gvd_table_row_{0}_cell_{1}", rows, i);
            cell.CssClass = "gvd_table_row_cell";
    
            //get the service ID
            int serviceid = Convert.ToInt32(dsServiceId.Tables[0].Rows[i]["pServiceID"].ToString());
    
            //create the grid control
            cell.Controls.Add(createGrid(serviceid));
    
            //add the cell to the row
            row.Cells.Add(cell);
    
            //Comment the next statement for all grids on one row.
            if (i % gridsPerRow == 0)
            {
                table.Rows.Add(row);
                rows++;
                row = new TableRow();
                row.ID = string.Format("gvd_table_row_{0}", rows);
                row.CssClass = "gvd_table_row";
            }
        }
        table.Rows.Add(row);
    
        PlaceHolder1.Controls.Add(table);
    }
    
    /// <summary>
    /// gets the service id
    /// </summary>
    /// <returns></returns>
    DataSet FetchServiceId()
    {
        //TODO: Fetch the data
        return new DataSet();
    }
    
    /// <summary>
    /// create the grid view for a item
    /// </summary>
    /// <param name="serviceID">the item</param>
    /// <returns></returns>
    GridView createGrid(int serviceID)
    {
        //TODO: Create your grid view
        return new GridView();
    }

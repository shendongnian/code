    private ArrayList ExcelData
    {
        get {
            object excel = Session["exceldata"];
            if (excel == null) Session["exceldata"] = new ArrayList();
            return (ArrayList)Session["exceldata"];
        }
        set {
            Session["exceldata"] = value;
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = (DropDownList)e.Row.FindControl("DrdDatabase");
            foreach (string colName in ExcelData)
                ddl.Items.Add(new ListItem(colName));
        }
    }

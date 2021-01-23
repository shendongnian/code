    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("univirsity", typeof(int));
            dt.Columns.Add("major", typeof(int));
            // our new column
            dt.Columns.Add("selectedProduct", typeof(string));
            Session["MyDataTable"] = dt;
        }
        else
        {
            // on each postback, loop through the grid and update
            // the datatable
            // get our table AsEnumerable, so we can use LINQ expressions on it
            var table = ((DataTable)Session["MyDataTable"]).AsEnumerable();
            foreach (GridViewRow gridRow in GridView1.Rows)
            {
                // get this row's ID from the grid
                int id = Convert.ToInt32(gridRow.Cells[0].Text);
                // and get the matching datarow from the table
                var tableRow = table.Where(x => (int)x["ID"] == id)
                                    .SingleOrDefault();
                if (tableRow != null)
                {
                    var ddl = (DropDownList)gridRow.FindControl("dropdownlist1");
                    tableRow["selectedProduct"] = ddl.SelectedValue;
                }
            }
        }
        base.OnLoad(e);
    }
    void button1_Click(object sender, EventArgs e)
    {
        DataTable t = (DataTable)Session["MyDataTable"];
        DataRow   row1 = t.NewRow();
        row1["ID"] = t.Rows.Count + 1;
        row1["univirsity"] = 3;
        // set default value for new column
        row1["selectedProduct"] = "DMG";
        t.Rows.Add(row1);
        Session["MyDataTable"] = t;
        GridView1.DataSource = t;
        GridView1.DataBind();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        ArrayList list = new ArrayList();
        list.Add("DMG");
        list.Add("SVC");
        // get our table again
        var table = ((DataTable)Session["MyDataTable"]).AsEnumerable();
   
        foreach (GridViewRow gridRow in GridView1.Rows)
        {
            if (gridRow.RowType == DataControlRowType.DataRow)
            {
                // get our id and tablerow again
                int id = Convert.ToInt32(gridRow.Cells[0].Text);
                var tableRow = table.Where(x => (int)x["ID"] == id)
                                    .SingleOrDefault();
                // bind the list
                DropDownList dl = (DropDownList)gridRow.FindControl("dropdownlist1");
                dl.DataSource = list;
                dl.DataBind();
                // set value from tablerow.selectedProduct
                dl.SelectedValue = (string)tableRow["selectedProduct"];
            }
        }
    }

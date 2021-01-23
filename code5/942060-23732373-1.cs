        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = CreateDataTable();
            GridView1.DataBind();
        }
      
        private DataTable CreateDataTable()
        {
            DataTable myDataTable = new DataTable();
            DataColumn myDataColumn;
            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "id";
            myDataTable.Columns.Add(myDataColumn);
            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "username";
            myDataTable.Columns.Add(myDataColumn);
            DataRow row;
            row = myDataTable.NewRow();
            row["id"] = "1";
            row["username"] = "hungn";
            myDataTable.Rows.Add(row);
            DataRow row1;
            row1 = myDataTable.NewRow();
            row1["id"] = "2";
            row1["username"] = "hoanq";
            myDataTable.Rows.Add(row1);
            return myDataTable;
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Downl")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // get the GridViewRow where the command is raised
                GridViewRow Row = ((GridViewRow)GridView1.Rows[index-1]);
                LinkButton approve = Row.FindControl("lk1") as LinkButton;
                approve.Enabled = true;
                LinkButton rework = Row.FindControl("lk2") as LinkButton;
                rework.Enabled = true;
                LinkButton comment = Row.FindControl("lk3") as LinkButton;
                comment.Enabled = false;
            
            }
        }
 

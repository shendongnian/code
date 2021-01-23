        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow gridRow;
            switch (e.CommandName)
            {
                case "edit":
                    index = Convert.ToInt32(e.CommandArgument);
                    gridRow = GridView1.Rows[index];
                    //get your dropdownlist from the selected gridview row
                    DropDownList ddl1 = gridRow.FindControl("DropDownList1") as DropDownList;
                    //make the dropdownlist selected based on your given value
                    ddl1.Items.FindByValue("set your value here").Selected = true;
                    break;
            }
        }

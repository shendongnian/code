        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList1");
                if (ddl != null)
                {
                    ListItem li = ddl.Items.FindByText(DataBinder.Eval(e.Row.DataItem, "CODE").ToString());
                    if (li != null)
                        li.Selected = true;
                }
            }
        }

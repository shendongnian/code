    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl1 = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl1.NamingContainer;
            if (row != null)
            {`enter code here`
                DropDownList ddl2 = (DropDownList)row.FindControl("DropDownList3");
                {
                    //call the method for binding the second DDL based on the selected item on the first DDL
                    DataTable dt = BindDropDownList(ddl1.SelectedItem.Text);
                    ddl2.DataTextField = "Field1";
                    ddl2.DataValueField = "Field2";
                    ddl2.DataBind();
                }
            }
        }

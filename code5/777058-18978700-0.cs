    protected void btndelete_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
    
        for (int i = 0; i < listview1.Items.Count; i++)
        {
            ListViewDataItem items = listview1.Items[i];
            CheckBox chkBox = (CheckBox)items.FindControl("chkdel");
    
            if (chkBox.Checked == true)
            {
                if (Session["CurrentTable"] != null)
                {
                    dt = (DataTable)Session["CurrentTable"];
                    dt.Rows.RemoveAt(i);
                    Session["CurrentTable"]=dt;
                }
            }
            else
            {
            }
        }
    
        Session["CurrentTable"] = dt;
        listview1.DataSource = dt;
        listview1.DataBind();
        BindDataToGridviewDropdownlist();     
    }

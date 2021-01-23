            DataTable dt = new DataTable();
            if (Session["CurrentTable"] != null)
            {
                dt = (DataTable)Session["CurrentTable"];
                int j = 0;
                for (int i = 0; i < listview1.Items.Count; i++)
                {
                    ListViewDataItem items = listview1.Items[i];
                    CheckBox chkBox = (CheckBox)items.FindControl("chkdel");
 
                    if (chkBox.Checked == true)
                    {
                        dt.Rows.RemoveAt(j);
                        dt.AcceptChanges();
                    }
                    else
                    {
                        j++;
                    }
                }
                Session["CurrentTable"] = dt;
                listview1.DataSource = dt;
                listview1.DataBind();
                BindDataToGridviewDropdownlist();
            }
        }

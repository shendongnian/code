    private void contructColumn()
            {
                DataTable dt = ds.Tables[0];
                DropDownList ddl = new DropDownList();
                TextBox txt = new TextBox();
                int index = 1;
                int indexenabled = 1;
                foreach (GridViewRow row in gvOrder.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        ddl = row.FindControl("ddlNewO") as DropDownList;
                        txt = row.FindControl("txtNewT") as TextBox;
                    }
                    if (row.RowIndex == 0)
                    {
                        ddl.Items.Add("1");
                        ddl.Enabled = false;
                        txt.Enabled = false;
    
                    }
                    else if (row.RowIndex != 0)
                    {
                        ddl.Items.Remove("1");
                        //Create ED button
    
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            Button btnED = new Button();
                            btnED.ID = "btnED"+row.RowIndex;
                            btnED.CssClass = "buttonsmall";
                            btnED.CommandName = "ED";
                            btnED.EnableViewState = true;
    
                            DataRow r = dt.Rows[row.RowIndex];
                            if (r.ItemArray[3].ToString() == "1")
                            {
                                btnED.Text = "Disable";
                                row.CssClass = "RowEnabled";
                                foreach (DataRow r2 in dt.Rows)
                                {
                                    if (r2.ItemArray[3].ToString() == "1")
                                    {
    
                                        string listitem = Convert.ToString(indexenabled + 1);
                                        ddl.Items.Add(listitem);
                                        indexenabled++;
                                    }
    
                                }
                                int itemtoremove = ddl.Items.Count + 1;
                                ddl.Items.Remove(itemtoremove.ToString());
    
                                ddl.SelectedIndex = idxselected;
                                idxselected++;
                            }
                            else if (r.ItemArray[3].ToString() == "0")
                            {
                                btnED.Text = "Enable";
                                row.CssClass = "RowDisabled";
                                ddl.Enabled = false;
                                txt.Enabled = false;
    
                                foreach (DataRow r1 in dt.Rows)
                                {
                                    string listitem = Convert.ToString(index);
                                    ddl.Items.Add(listitem);
                                    index++;
                                }
                                ddl.SelectedIndex = row.RowIndex;
                            }
    
                            //Add button to grid
                            row.Cells[6].Controls.Add(btnED);
                        }
                    }
                }
            }

       void AddNewRowToGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    for (int i = 0; i < dtCurrentTable.Rows.Count-1; i++)
                    {
                        DropDownList list1 = (DropDownList)Gridview1.Rows[i].Cells[1].FindControl("DropDownList1");
                        DropDownList list2 = (DropDownList)Gridview1.Rows[i].Cells[2].FindControl("DropDownList2");
                        TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("TextBox1");
                        TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[4].FindControl("TextBox2");
                        DropDownList list3 = (DropDownList)Gridview1.Rows[i].Cells[5].FindControl("DropDownList3");
                        TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[6].FindControl("TextBox3");
                        dtCurrentTable.Rows[i]["Column1"] = list1.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column2"] = list2.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column3"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column4"] = box2.Text;
                        dtCurrentTable.Rows[i]["Column5"] = list3.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["Column6"] = box3.Text;
                    }
                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

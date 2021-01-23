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
    void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList list1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("DropDownList1");
                    DropDownList list2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("DropDownList2");
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("TextBox2");
                    DropDownList list3 = (DropDownList)Gridview1.Rows[rowIndex].Cells[5].FindControl("DropDownList3");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("TextBox3");
                    Fillcombo();
                    Fillcombo1();
                    Fillcombo2();
                    
                    box1.Text = dt.Rows[i]["Column3"].ToString();
                    box2.Text = dt.Rows[i]["Column4"].ToString();                    
                    box3.Text = dt.Rows[i]["Column6"].ToString();
                        if (i < dt.Rows.Count - 1)
                        {
                            list1.ClearSelection();
                            list1.Items.FindByText(dt.Rows[i]["Column1"].ToString()).Selected = true;
                            list2.ClearSelection();
                            list2.Items.FindByText(dt.Rows[i]["Column2"].ToString()).Selected = true;
                            list3.ClearSelection();
                            list3.Items.FindByText(dt.Rows[i]["Column5"].ToString()).Selected = true;
                        }
                    rowIndex++;
                }
            }
        }
     }
      protected void ButtonAdd_Click(object sender, EventArgs e)
      {
            AddNewRowToGrid();
      }

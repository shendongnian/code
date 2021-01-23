        //to check repeated item in the gridview
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            if (dtCurrentTable.Rows.Count > 1)
            {
               
                for (int i = 1; i <= dtCurrentTable.Rows.Count-1; i++)
                {
                    if (dtCurrentTable.Rows.Count > 1)
                    {
                        TextBox prevItem = (TextBox)Grid_ItemList.Rows[rowIndex].Cells[1].FindControl("itemCode");
                        if (prevItem.Text == itemcode && currentRow.RowIndex != rowIndex)
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation1", "<script language='javascript'>alert('Item Alredy Added, Please change the Qty if needed.')</script>");
                            txt.Text = "";
                            qtyl.Enabled = false;
                            return;
                        }
                    }
                    rowIndex++;
                }
            }
            SetRowData();
        } 

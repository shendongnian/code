     private void SetPreviousData()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count-1; i++)
                    {
                        DropDownList itemDropDownList =
                          (DropDownList)PurchaseMgmtGridView.Rows[i].Cells[0].FindControl("ItemDropDownList");
                        DropDownList itemUnitDropDownList =
                          (DropDownList)PurchaseMgmtGridView.Rows[i].Cells[1].FindControl("ItemUnitDropDownList");
                        TextBox rateTextBox =
                          (TextBox)PurchaseMgmtGridView.Rows[i].Cells[2].FindControl("RateTextBox");
                        TextBox qtyTextBox =
                          (TextBox)PurchaseMgmtGridView.Rows[i].Cells[3].FindControl("QtyTextBox");
                        Label totalLabel =
                          (Label)PurchaseMgmtGridView.Rows[i].Cells[4].FindControl("TotalLabel");
    
                        FillItemDropDownList(itemDropDownList);
                        FillItemUnitDropDownList(itemUnitDropDownList);
    
    
                        if (i < dt.Rows.Count - 1)
                        {
                            //itemDropDownList.SelectedValue = dt.Rows[i]["Item"].ToString();
                            //itemUnitDropDownList.SelectedValue = dt.Rows[i]["ItemUnit"].ToString();
                            itemDropDownList.ClearSelection();
                            itemDropDownList.Items.FindByText(dt.Rows[i]["Item"].ToString()).Selected = true;
                            itemUnitDropDownList.ClearSelection();
                            itemUnitDropDownList.Items.FindByText(dt.Rows[i]["ItemUnit"].ToString()).Selected = true;
                        }
    
                        rateTextBox.Text = dt.Rows[i]["Rate"].ToString();
                        qtyTextBox.Text = dt.Rows[i]["Qty"].ToString();
                        totalLabel.Text = dt.Rows[i]["Total"].ToString();                        
                    }
                }
            }
        }

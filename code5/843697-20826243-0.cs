    protected void lbnConfirm_Click(object sender, EventArgs e)
    {
        List<string> quantity = new List<string>(); 
        prodID = "";
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                Panel pnl = item.FindControl("pBody1") as Panel;
                GridView gv = pnl.FindControl("gvProduct") as GridView;
                foreach (GridViewRow gr in gv.Rows)
                {
                    CheckBox cb = (CheckBox)gr.Cells[0].FindControl("cbCheckRow");
                    if (cb.Checked)
                    {
                        //Get the productID which set as DataKeyNames for selected row index
                        prodID = gv.DataKeys[gr.RowIndex].Value.ToString();
                        var tbQuantity = gr.FindControl("tbQuantity") as TextBox;
                        if (tbQuantity != null)
                        {
                            quantity.Add(tbQuantity.Text);
                        }
                        tempList.Add(prodID);
                    }  
                }
            }
        }
        for (int i = 0; i < tempList.Count; i++)
        {    
            //Testing
            lblTest.Text += tempList[i] + " " + quantity[i];
        }
    }

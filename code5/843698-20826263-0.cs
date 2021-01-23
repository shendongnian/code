    protected void lbnConfirm_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> tempList = new Dictionary<string, string>();
        string quantity = "", prodID = "";
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
                            quantity = tbQuantity.Text;
                        }
                        tempList.Add(prodID, quantity);
                    }
                }
            }
        }
        
        foreach (string key in tempList.Keys)
        {
            lblTest.Text += key + " " + tempList[key];
        }
    }

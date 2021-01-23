    protected void lbnConfirm_Click(object sender, EventArgs e)
    {
        List<string> tempList = new List<string>();
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
                        //GridViewRow row = gv.SelectedRow;
                        string prodID =  gv.DataKeys[gr.RowIndex].Value.ToString();
                        List<DistributionStandardPackingUnitItems> distSPUList = new List<DistributionStandardPackingUnitItems>();
                        //Store the prodIDs into list
                        tempList.Add(prodID);                        
                    }
    
                }
            }
        }  
    
        lblTest.Text = string.Join(",", tempList);       
    }

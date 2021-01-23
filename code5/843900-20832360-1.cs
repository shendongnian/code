    private Dictionary<string, string> tempList
    {
        get
        {
            if (ViewState["tempList"] == null)
            {
                return new Dictionary<string,string>();
            }
            else
            {
                return (Dictionary<string, string>)ViewState["tempList"];
            }
        }
        set
        {
            ViewState["tempList"] = value;
        }
    }
    
    private Dictionary<string, string> distSPUItemList
    {
        get
        {
            if (ViewState["distSPUItemList"] == null)
            {
                return new Dictionary<string, string>();
            }
            else
            {
                return (Dictionary<string, string>)ViewState["distSPUItemList"];
            }
        }
        set
        {
            ViewState["distSPUItemList"] = value;
        }
    }
    
    protected void tbQuantity_TextChanged(object sender, EventArgs e)
    {
        tempList = new Dictionary<string, string>();
        distSPUItemList = new Dictionary<string, string>(); 
        
        string quantity = "", prodID = "";
        int packagesNeeded = 0, totalUnit = 0;
    
        //Get the total packages needed for this distribution
        packagesNeeded = prodPackBLL.getPackagesNeededByDistributionID(distributionID);
    
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
                        //Clear label error message
                        Label lblCheckAmount = gr.FindControl("lblCheckAmount") as Label;
                        lblCheckAmount.Text = "";
    
                        //Get the productID which set as DataKeyNames and unit quantity from selected row index
                        prodID = gv.DataKeys[gr.RowIndex].Value.ToString();
    
                        var tbQuantity = gr.FindControl("tbQuantity") as TextBox;
                        if (tbQuantity != null)
                        {
                            quantity = tbQuantity.Text;
                        }
    
                        //Add both objects into Dictionary
                        tempList.Add(prodID, quantity);
                    }
                }
            }
        }
        //Loop thru tempList. key as prodID, tempList.Keys as quantity
        foreach (string key in tempList.Keys)
        {
            //Get total unit of each products
            totalUnit = prodPackBLL.getTotalProductUnit(key);
            //lblTest.Text += key + " " + tempList[key] + "units";
    
            //Check if unitQuantity exceed storage level
            if (((Convert.ToInt32(tempList[key])) * packagesNeeded) > totalUnit)
            {
                //Get the label control in gridview
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    Panel pnl = item.FindControl("pBody1") as Panel;
                    GridView gv = pnl.FindControl("gvProduct") as GridView;
                    foreach (GridViewRow gr in gv.Rows)
                    {
                        //Compare the key with the data key of the current row
                        if (key == gv.DataKeys[gr.RowIndex].Value.ToString())
                        {
                            //Display the insufficient message
                            Label lblCheckAmount = gr.FindControl("lblCheckAmount") as Label;
                            lblCheckAmount.Text = "Insufficient amount";
                        }
                    }
                }
            }
            else
            {
                distSPUItemList.Add(key, tempList[key]);
            }
        }
    }

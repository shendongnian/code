        //Loop thru tempList. key as prodID, tempList.Keys as quantity
        foreach (string key in tempList.Keys)
        {
            //Get total unit of each products
            totalUnit = prodPackBLL.getTotalProductUnit(key);
            //Here check if exceed storage
            if (((Convert.ToInt32(tempList[key])) * packagesNeeded) > totalUnit)
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    Panel pnl = item.FindControl("pBody1") as Panel;
                    GridView gv = pnl.FindControl("gvProduct") as GridView;
                    foreach (GridViewRow gr in gv.Rows)
                    {
                        // compare the key with the data key of the current row
                        if (key == gv.DataKeys[gr.RowIndex].Value.ToString())
                        {
                            // display the insufficient message
                            Label lblCheckAmount = gr.FindControl("lblCheckAmount") as Label;
                            lblCheckAmount.Text = "Insufficient amount";
                        }
                    }
                }
            }
        }

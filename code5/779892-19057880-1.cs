    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        //pass index of item in command argument
        int itemIndex = Convert.ToInt32(e.CommandArgument);      
        //depending on your needs bind the details on demand
        //or preload during ItemDataBound 
        Panel childViewPanel = (Panel)DataList1.Items[itemIndex].FindControl("pnlChildView");
        if (childViewPanel != null)
        {
            //toggle visibility of childViewPanel and bind child list if panel is visible
            if (childViewPanel.Visible)
            {
                DataList childList = childViewPanel.FindControl("DataList2");
                if (childList != null)
                {
                    int keyValue = (int)DataList1.DataKeys[itemIndex];
                    //bind the list using DataList1 data key value
                    childList.DataSource = <DATA SOURCE>; //get data using keyValue
                    childList.DataBind();
                }  
            }
        }
    }

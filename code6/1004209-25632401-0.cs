    UpdateAction action = DataBinder.Eval(e.Item.DataItem, "UpdateAction");
    if (action == UpdateAction.Update)
    {
        pnlUpdateItems.Visible = true;
    }
    else
    {    
        pnlUpdateItems.Visible = false;
    }
 

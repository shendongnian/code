    protected void RPTR_DeleteTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       var lb = e.Item.Controls[1] as LinkButton; // for simplicity only - do not use code like this
       lb.OnClientClick = String.Format("$('#{0}').val('{1}');$('#{2}').click();return false;",                                         
                     HF_DeleteId.ClientID, 
                     DataBinder.Eval(e.Item.DataItem, "ID"),
                     B_Delete.ClientID);
    }
    protected void B_Delete_Click(object sender, EventArgs e)
    {
        int id = Int32.Parse(HF_DeleteId.Value);
        // do your sanity checks and deletion logic here
    }

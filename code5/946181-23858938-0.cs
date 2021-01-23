private bool isGetChildItems = false;
protected void Page_Load(object sender, EventArgs e)
{
    if (IsPostBack)
    {
        //if ( your condition that requires access to  child items )
        {
            isGetChildItems = true;
            //your logic to expand whichever nodes you need
            RadTreeList1.Items[0].Expanded = true;
        }
    }
}
protected void RadTreeList1_DataBound(object sender, EventArgs e)
{
    //At this point in the lifecycle we can access the child items
    if (isGetChildItems)
    {
        //Do whatever it is we need to do with the child items
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", string.Format("alert('Item 0 has {0} child items')", RadTreeList1.Items[0].ChildItems.Count), true);
    }
}
protected void RadTreeList1_PreRender(object sender, EventArgs e)
{
    if (isGetChildItems)
    {
        //Restore node state, clear our flag and rebind
        isGetChildItems = false;
        RadTreeList1.Items[0].Expanded = false;
        RadTreeList1.DataBind();
    }
}

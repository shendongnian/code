    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var items = new List<MyDataItem>();
            items.Add(new MyDataItem() { Name = "Item1", Category = "Cat1" });
            items.Add(new MyDataItem() { Name = "Item2", Category = "Cat2" });
            items.Add(new MyDataItem() { Name = "Item3", Category = "Cat1" });
            items.Add(new MyDataItem() { Name = "Item4", Category = "Cat2" });
            items.Add(new MyDataItem() { Name = "Item5", Category = "Cat1" });
            rpt.DataSource = items;
            rpt.DataBind();
        }
    }
    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item 
            || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var multiView = e.Item.FindControl("multiView") as MultiView;
            if (multiView != null)
                multiView.ActiveViewIndex = 
                    ((MyDataItem)e.Item.DataItem).Category == "Cat1" ? 0 : 1;
        }
    }
    public class MyDataItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
    }

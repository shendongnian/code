    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }
    
            private void BindData()
            {
                List<TestItem> items = new List<TestItem>()
                {
                    new TestItem() {ItemText = "Item1"},
                    new TestItem() {ItemText = "Item2"},
                    new TestItem() {ItemText = "Item3"},
                    new TestItem() {ItemText = "Item4"},
                    new TestItem() {ItemText = "Item5"},
                    new TestItem() {ItemText = "Item6"},
                    new TestItem() {ItemText = "Item7"},
                    new TestItem() {ItemText = "Item8"},
                    new TestItem() {ItemText = "Item9"},
                    new TestItem() {ItemText = "Item10"},
                    new TestItem() {ItemText = "Item11"},
                    new TestItem() {ItemText = "Item12"}
                };
    
                gvTest.DataSource = items.Skip(gvTest.PageIndex * gvTest.PageSize).Take(gvTest.PageSize).ToList();
                gvTest.VirtualItemCount = items.Count;
                gvTest.DataBind();
            }
    
            protected void gvTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                gvTest.PageIndex = e.NewPageIndex;
                BindData();
            }
        }
    
        public class TestItem
        {
            public string ItemText { get; set; }
        }

    public class Test
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataSource = new List<Test>()
            {
                new Test { Id = 1, Question = "One", A = true, B = false, C = true},
                new Test { Id = 2, Question = "Two", A = false, B = true, C = true},
                new Test { Id = 3, Question = "Three", A = false, B = true, C = true},
            };
            Repeater1.DataBind();
        }
    }
    
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            RepeaterItem item = e.Item;
            var test = e.Item.DataItem as Test;
    
            var a = item.FindControl("chkModel_A") as CheckBox;
            a.Checked = test.A;
    
            var b = item.FindControl("chkModel_B") as CheckBox;
            b.Checked = test.B;
    
            var c = item.FindControl("chkModel_C") as CheckBox;
            c.Checked = test.C;
        }
    }

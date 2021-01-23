    public class Something
    {
        public string Some { get; set; }
        public bool IsExcluded { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var collections = new List<Something>
            {
                new Something {Some = "One", IsExcluded = true},
                new Something {Some = "Two", IsExcluded = false},
            };
            GridView1.DataSource = collections;
            GridView1.DataBind();
        }
    }

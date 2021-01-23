    public class Test
    {
        public int Beg_PlanYr { get; set; }
        public decimal indTotPaid { get; set; }
        public decimal indTotCopay { get; set; }
        public decimal indTotDed { get; set; }
        public decimal indTotOop { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvwAccums.DataSource = new List<Test>()
            {
                new Test {Beg_PlanYr = 1, indTotPaid = 1, indTotCopay = 1, indTotDed = 1, indTotOop = 1},
                new Test {Beg_PlanYr = 2, indTotPaid = 2, indTotCopay = 2, indTotDed = 2, indTotOop = 2},
                new Test {Beg_PlanYr = 3, indTotPaid = 3, indTotCopay = 3, indTotDed = 3, indTotOop = 3},
            };
            gvwAccums.DataBind();
        }
    }
    
    protected void gvwAccums_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].ToolTip = "xxxxx ";
            e.Row.Cells[1].ToolTip = "yyyyy ";
            e.Row.Cells[2].ToolTip = "zzzzz ";
            e.Row.Cells[3].ToolTip = "fffff ";
            e.Row.Cells[4].ToolTip = "vvvvv ";
        }
    }

        private GridView gv;
        protected void Page_Init(object sender, EventArgs e)
        {
            gv = new GridView();
            gv.ID = "gv";
            gv.AutoGenerateColumns = false;
            gv.Columns.Add(new TemplateField());
            gv.RowCreated += gv_RowCreated;
            gv.RowDataBound += gv_RowDataBound;
            pnl.Controls.Add(gv);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv.DataSource = new object[] {
                    new object()
                };
                gv.DataBind();
            }
        }
        void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var lb = e.Row.FindControl("Update") as LinkButton;
            lb.CommandArgument = "1";
        }
        void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            // If you bind gridview after Page_Init,
            // This event will not be fired after postback.
            LinkButton lb = new LinkButton();
            lb.ID = "Update";
            lb.Text = "Update";
            lb.Click += lb_Click;
            e.Row.Cells[e.Row.Cells.Count - 1].Controls.Add(lb);
        }
        void lb_Click(object sender, EventArgs e)
        {
            var lb = (LinkButton)sender;
            string arg = lb.CommandArgument;
        }

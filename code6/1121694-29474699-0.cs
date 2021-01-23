    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ArrayList al = new ArrayList();
                    al.Add("open"); al.Add("close"); al.Add("other"); al.Add("open"); al.Add("other"); al.Add("close"); al.Add("open");
                    this.GridView1.DataSource = al;
                    this.GridView1.DataBind();
                }
            }
    
    	        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[0].Text == "open")
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                    }
                    else if (e.Row.Cells[0].Text == "close")
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Black;
                    }
                    else
                    {
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Green;
                    }
                }
            }

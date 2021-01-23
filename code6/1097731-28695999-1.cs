    protected void Page_Load(object sender, EventArgs e)
             {
                            if (!IsPostBack)
                            {
                                DataTable dt = BindGridView();
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
              }
        private DataTable BindGridView(string name = null)
        {
            string connectionString = "Data Source=.SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                if (name != null)
                {
                    cmd.CommandText = "SELECT * FROM ORDERS WHERE Name='" + name + "'";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM ORDERS";
                }
    
                cmd.Connection = con;
                con.Open();
    
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
        }
    
        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=exportdata.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                GridView gv = new GridView();
                gv.DataSource = BindGridView("Scott"); // Seelct all the order where Name='Scott' - my filter query
                gv.DataBind();
    
                gv.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

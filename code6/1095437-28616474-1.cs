        protected void ShowinGrid_Click(object sender, EventArgs e)
            {
            SqlConnection thisConnection = new SqlConnection("server=.;database=local;Integrated Security=SSPI");
            SqlCommand thisCommand = new SqlCommand("select * from tbluser where SponsorIDNum=0", thisConnection);// this is where you write the sql query for members.
            SqlDataAdapter ad = new SqlDataAdapter(query, thisConnection);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Categories");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            }
        protected void exporttoExcel_Click(object sender, EventArgs e)
            {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";
            // If you want the option to open the Excel file without saving then
            // comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GridView1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            }
        public override void VerifyRenderingInServerForm(Control control)
            {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
            }

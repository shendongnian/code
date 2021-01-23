     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Dosage", typeof(int));
                table.Columns.Add("Drug", typeof(string));
                table.Columns.Add("Patient", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));
                // Here we add five DataRows.
                table.Rows.Add(25, "Indocin", "David", DateTime.Now);
                table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
                table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
                table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
                table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
                GridView1.DataSource = table;
                GridView1.DataBind();
                ViewState["Ledger"] = table;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=LedgerReport.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            htmlWrite.Write("<table><tr><td colspan='4'><center>Report Date </center></td></tr></table>");
            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            GridView1.DataSource = (DataTable)ViewState["Ledger"];
            GridView1.DataBind();
            for (int i = 0; i <= GridView1.Columns.Count - 1; i++)
            {
                GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#2FA4E7");
                GridView1.HeaderRow.Cells[i].Style.Add("color", "#FFFFFF");
            }
            GridView1.RenderControl(htmlWrite);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

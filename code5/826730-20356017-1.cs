    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void btnExportCSV_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
    
            GridView1.AllowPaging = false;
            GridView1.DataBind();
    
            StringBuilder sb = new StringBuilder();
            //add separator for header
            sb.Append(GridView1.Columns[0].HeaderText).Append(",")
    	        .Append(GridView1.Columns[1].HeaderText).Append(",")
    	        .Append(GridView1.Columns[2].HeaderText).Append(",")
    	        .Append(GridView1.Columns[4].HeaderText).Append(",")
    	        .Append(GridView1.Columns[7].HeaderText).Append("\r\n");
           
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                DateTime date = DateTime.Parse(GridView1.Rows[i].Cells[1].Text);
 
                if (date.DayOfWeek != DayOfWeek.Saturday 
                     && date.DayOfWeek != DayOfWeek.Sunday) 
                {
                   //add separator for each row
    	           sb.Append(GridView1.Rows[i].Cells[0].Text).Append(",")
    	           .Append(GridView1.Rows[i].Cells[1].Text).Append(",")
    	           .Append(GridView1.Rows[i].Cells[2].Text).Append(",")
    	           .Append(GridView1.Rows[i].Cells[4].Text).Append(",")
    	           .Append(GridView1.Rows[i].Cells[7].Text).Append("\r\n");
                }
            }
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
    }

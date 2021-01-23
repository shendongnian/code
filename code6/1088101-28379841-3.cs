    public void bindRepeater()
    {
           DataTable dtInfo = new DataTable();
           dtInfo.Columns.Add("News_Title");
           dtInfo.Columns.Add("News_Time");
           DataRow dr;
           for (int i = 0; i < 5; i++)
           {
               dr = dtInfo.NewRow();
               dr["News_Time"] = DateTime.Now.ToShortDateString();
               dr["News_Title"] = "Recongition statement";
               dtInfo.Rows.Add(dr);
          }
          rptNews.DataSource = dtInfo;
          rptNews.DataBind();
    }
     protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
            bindRepeater();
        }
     } 

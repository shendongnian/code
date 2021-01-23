    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Default.aspx");
        }
        int id = Convert.ToInt32(Session["userid"]);
        pl.userid = id;
        pl.SubMenuId = "14";
        DataTable dt1 = bl.method(pl);
        if (dt1.Rows.Count == 0)
        {
            Response.Redirect("AdminZone.aspx");
        }
         ReportDocument rt = new ReportDocument();
            DataSet1 dt = new DataSet1();
            LoadReport(rt, dt);
        
        
    }
    public void LoadReport( ReportDocument rt, DataSet1 dt )
    {
        SqlDataAdapter da = bl.getsoldcards(pl);
        da.Fill(dt);
        rt.Load(Server.MapPath("report/SoldCard.rpt"));
        rt.SetDataSource(dt.Tables[0]);
        CrystalReportViewer1.ReportSource = rt;
    }

    public void bind()
    {
        dt = g1.return_dt("select * from tb1 where Name='" + TextBox1.Text.Text + "' or compname='"+TextBox1.Text+"'  order by  compname ");
        if (dt.Rows.Count > 0)
        {
            adsource = new PagedDataSource();
            adsource.DataSource = dt.DefaultView;
            adsource.PageSize = 10;
            adsource.AllowPaging = true;
            adsource.CurrentPageIndex = pos;
            btnfirst.Enabled = !adsource.IsFirstPage;
            btnprevious.Enabled = !adsource.IsFirstPage;
            btnlast.Enabled = !adsource.IsLastPage;
            btnnext.Enabled = !adsource.IsLastPage;
            GridView1.DataSource = adsource;
            GridView1.DataBind();
         }
         else
         {
             GridView1.DataSource = null;
             GridView1.DataBind();
         }
    }

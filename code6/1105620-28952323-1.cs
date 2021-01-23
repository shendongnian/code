    protected void Page_Load(object sender, EventArgs e) {
        string searchWord = Session["searchWord"].ToString();
        ZaraEntities db = new ZaraEntities();
        var results = db.Products.Where(p => p.Name.Contains(searchWord));
        rptrSearch.DataSource = results.ToList();
        rptrSearch.DataBind();
        litResults.Text = string.Format("<p>Search results for '{0}'. {1} Results found.</p>", txtWord.Text, results.ToList().Count);
    }

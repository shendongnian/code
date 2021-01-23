    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchWord = txtWord.Text;
        ZaraEntities db = new ZaraEntities();
        var results = db.Products.Where(p => p.Name.Contains(searchWord));
        rptrSearch.DataSource = results.ToList();
        rptrSearch.DataBind();
        litResults.Text = "<p>" + "Search results for " + "'" + txtWord.Text + "'" + " ("+ results.ToList().Count + ") Results found.</p>";
    }

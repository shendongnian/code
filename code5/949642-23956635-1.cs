    protected void Page_InIt(object sender, EventArgs e)
    {
        BindGrid("Customers");
    }
    
    private void BindGrid(string strDataSourceType)
    {
        var customers, providers = null;
    
        if (strDataSourceType == "Customers")
        {
            customers = (from x in Context.Customers
                         select new
                         {
                             CustomerId = x.ID,
                             CustomerName = x.Name
                         }).ToList();
        }
        else if (strDataSourceType == "Providers")
        {
            providers = (from x in Context.Providers
                         select new
                         {
                             ProviderId = x.ID,
                             ProviderName = x.Name
                         }).ToList();
        }
    
        grid.DataSource = customers / providers;
        grid.AutoGenerateColumns = true;
        grid.DataBind();
    }

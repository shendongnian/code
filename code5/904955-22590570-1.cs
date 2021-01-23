    List<CompanyDetails> details = GetCompanyDetails();
    IEnumerable<GrouppedCompanyDetails> grouppedDetails = details
        .GroupBy(sp => new { sp.Company, sp.City, sp.State })
        .Select(gsp => new GrouppedCompanyDetails()
        {
            Address = String.Format("{0}<br/>{1}, {2}", gsp.Key.Company, gsp.Key.City, gsp.Key.State),
            SalesPerson = gsp.Select(x => x.SalesPerson).ToList()
        });
    MasterLS.DataSource = grouppedDetails;
    MasterLS.DataBind();

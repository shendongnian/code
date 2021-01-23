    List<CompanyDetails> details = GetCompanyDetails();
    IEnumerable<GroupedCompanyDetails> groupedDetails = details
        .GroupBy(sp => new { sp.Company, sp.City, sp.State })
        .Select(gsp => new GroupedCompanyDetails()
        {
            Address = String.Format("{0}<br/>{1}, {2}", gsp.Key.Company, gsp.Key.City, gsp.Key.State),
            SalesPerson = gsp.Select(x => x.SalesPerson).ToList()
        });
    MasterLS.DataSource = groupedDetails;
    MasterLS.DataBind();

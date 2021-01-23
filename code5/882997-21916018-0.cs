	// single column sorting support
	var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
	Func<LegalComplianceDatatable, string> orderingFunction = (c => sortColumnIndex == 0 ? c.HomeCountry :
														sortColumnIndex == 1 ? c.HostCountry :
														sortColumnIndex == 2 ? c.YearOneRate :
														sortColumnIndex == 3 ? c.YearOtherRate :
														sortColumnIndex == 4 ? c.RateType :
														c.HostCountry);
	if (Request["sSortDir_0"] == "desc")
	{
		filteredResults = filteredResults.OrderByDescending(orderingFunction);
	}
	else
	{
		filteredResults = filteredResults.OrderBy(orderingFunction);
	}

	var context = System.Web.HttpContext.Current;
	var stations = this.Stations.Where(s => s.Active);
	if (!context.User.IsInRole("Acctg") && !context.User.IsInRole("Execs"))
	{
		var user = MembershipHelpers.GetUser();
		var stationIds = user.Stations.Select(s => s.Id).Distinct().ToList();
		stations = stations.Where(s => stationIds.Contains(s.Id));
	}
	return stations;
}

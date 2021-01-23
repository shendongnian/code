	[Authorize(Roles = "OneRoleHere")]
	[GET("/api/admin/settings/product/allorgs")]
	[HttpGet]
	public List<Org> GetAllOrganizations()
	{
		return QueryableDependencies.GetMergedOrganizations().ToList();
	}
	[Authorize(Roles = "ADifferentRoleHere")]
	[GET("/api/admin/settings/product/allorgswithapproval")]
	[HttpGet]
	public List<ApprovableOrg> GetAllOrganizationsWithApproval()
	{
		return QueryableDependencies.GetMergedOrganizationsWithApproval().ToList();
	}

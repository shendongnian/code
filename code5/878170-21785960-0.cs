	protected void Page_Load(object sender, EventArgs e)
	{
		RouteHelper.SetUrlParametersResolved();
		string urlParams = this.GetUrlParameterString(true);
		if (!string.IsNullOrEmpty(urlParams))
		{
			urlParams = urlParams.Replace("/", string.Empty);
			var dynamicModuleManager = DynamicModuleManager.GetManager(string.Empty);
			var serviceType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Services.Service");
			var service = dynamicModuleManager.GetDataItems(serviceType).FirstOrDefault(s => s.Status == ContentLifecycleStatus.Live && s.UrlName == urlParams);
			if (service != null)
			{
				var businessUnits = GetBusinessUnits().Where(bu => bu.GetValue<Guid[]>("Services").Contains(service.OriginalContentId));
				foreach (var bu in businessUnits)
				{
					//do something cool
				}
			}
		}
	}
	public IQueryable<DynamicContent>GetBusinessUnits()
	{
		var providerName = String.Empty;
		DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName);
		Type businessUnitType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.BusinessAreas.BusinessUnit");
		var myCollection = dynamicModuleManager.GetDataItems(businessUnitType).Where(bu => bu.Status == ContentLifecycleStatus.Live);
		return myCollection;
	}

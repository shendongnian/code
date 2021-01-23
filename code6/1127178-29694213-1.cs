	public static EntityMetadata[] GetEntities ( IOrganizationService organizationService)
	{
		Dictionary<string, string> attributesData = new Dictionary<string, string>();
		RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
		RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
		metaDataRequest.EntityFilters = EntityFilters.All;
		
		// Execute the request.
		
		metaDataResponse = (RetrieveAllEntitiesResponse)organizationService.Execute(metaDataRequest);
		
		var entities = metaDataResponse.EntityMetadata;
		
		return entities;
	}

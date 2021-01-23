	private static bool RelationshipExists(IOrganizationService service, string relationshipname, Guid entity1Id, string entity1Name, Guid entity2Id, string entity2Name)
	{
		string relationship1EtityName = string.Format("{0}id", entity1Name);
		string relationship2EntityName = string.Format("{0}id", entity2Name);
		//This check is added for self-referenced relationships
		if (entity1Name.Equals(entity2Name, StringComparison.InvariantCultureIgnoreCase))
		{
			relationship1EtityName = string.Format("{0}idone", entity1Name);
			relationship1EtityName = string.Format("{0}idtwo", entity1Name);
		}
		QueryExpression query = new QueryExpression(entity1Name) { ColumnSet = new ColumnSet(false) };
		LinkEntity link = query.AddLink(relationshipname, 
		string.Format("{0}id", entity1Name), relationship1EtityName);
		link.LinkCriteria.AddCondition(relationship1EtityName, 
		ConditionOperator.Equal, new object[] { entity1Id });
		link.LinkCriteria.AddCondition(relationship2EntityName, 
		ConditionOperator.Equal, new object[] { entity2Id });
		return service.RetrieveMultiple(query).Entities.Count != 0;
	}

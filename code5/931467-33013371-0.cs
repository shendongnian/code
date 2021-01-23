    private static void fetchRelatedPhoneCalls(IPluginExecutionContext context, IOrganizationService service, Guid yourGuid, Entity opp)
    {
	    string strFetchPhoneCalls = string.Format(FetchQuery.bringFetchQueryForPhoneCalls(),yourGuid);
	    EntityCollection entPhoneCalls = (EntityCollection)service.RetrieveMultiple(new FetchExpression(strFetchPhoneCalls));
	    if (entPhoneCalls != null && entPhoneCalls.Entities.Count > 0)
	    {
		    for (int i = 0; i < entPhoneCalls.Entities.Count; i++)
		    {
			    Entity entPhoneCall = (Entity)entPhoneCalls.Entities[i];
			    string[] strAttributesPCtoRemove = new string[] { "createdon", "createdbyname", "createdby"
								,"modifiedon", "modifiedby" ,"regardingobjectid","owninguser"
								,"activityid", "instancetypecode", "activitytypecode" // PhoneCall Skip
			    };
			    Entity entNewPhoneCall = this.CloneRecordForEntity("phonecall", entPhoneCall, strAttributesPCtoRemove);
			    entNewPhoneCall["regardingobjectid"] = new EntityReference(context.PrimaryEntityName, context.PrimaryEntityId);
			    entNewPhoneCall["to"] = this.getActivityObject(entNewPhoneCall, "to");
			    entNewPhoneCall["from"] = this.getActivityObject(entNewPhoneCall, "from");
			    service.Create(entNewPhoneCall);
		    }
	    }
    }
    private static Entity CloneRecordForEntity(string targetEntityName, Entity sourceEntity, string[] strAttributestoRemove)
    {
	    Entity clonedEntity = new Entity(targetEntityName);
	    AttributeCollection attributeKeys = sourceEntity.Attributes;
	    foreach (string key in attributeKeys.Keys)
	    {
		    if (Array.IndexOf(strAttributestoRemove, key) == -1)
		    {
			    if (!clonedEntity.Contains(key))
			    {
			    	clonedEntity[key] = sourceEntity[key];
			    }
		    }
	    }
	    return clonedEntity;
    }
    private static EntityCollection getActivityObject(Entity entNewActivity, string activityFieldName)
    {
	    Entity partyToFrom = new Entity("activityparty");
	    partyToFrom["partyid"] = ((EntityReference)((EntityCollection)entNewActivity[activityFieldName]).Entities[0].Attributes["partyid"]);
	    EntityCollection toFrom = new EntityCollection();
	    toFrom.Entities.Add(partyToFrom);
	    return toFrom;
    }

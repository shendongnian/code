    EntityMetadata entityMetaData = retrieveEntityResponse.EntityMetadata;
    for (int count = 0; count < entityMetaData.Attributes.ToList().Count; count++)
    {
    	if (entityMetaData.Attributes.ToList()[count].DisplayName.LocalizedLabels.Count > 0)
    	{
    		string displayName = entityMetaData.Attributes.ToList()[count].DisplayName.LocalizedLabels[0].Label;
    		string logicalName = entityMetaData.Attributes.ToList()[count].LogicalName;
    		AttributeTypeCode dataType = (AttributeTypeCode)entityMetaData.Attributes.ToList()[count].AttributeType;
    	}
    }

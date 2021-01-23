    /// <summary>
    /// Retrieves an entity's attributes.
    /// </summary>
    /// <param name="entityName">entity's name</param>
    /// <param name="languageId">return display names of such language code</param>
    /// <param name="xrm">xrmservicecontext object</param>
    /// <returns>Dictionary<string, string></returns>
    public static Dictionary<string, string> GetAttributes(string entityName, int languageId, XrmServiceContext xrm)
    {
        Dictionary<string, string> attributesData = new Dictionary<string, string>();
        RetrieveEntityRequest metaDataRequest = new RetrieveEntityRequest();
        RetrieveEntityResponse metaDataResponse = new RetrieveEntityResponse();
        metaDataRequest.EntityFilters = EntityFilters.Attributes;
        metaDataRequest.LogicalName = entityName;
        metaDataResponse = (RetrieveEntityResponse)xrm.Execute(metaDataRequest);
        foreach (AttributeMetadata a in metaDataResponse.EntityMetadata.Attributes)
        {
            //if more than one label for said attribute, get the one matching the languade code we want...
            if (a.DisplayName.LocalizedLabels.Count() > 1)
                attributesData.Add(a.LogicalName, a.DisplayName.LocalizedLabels.Where(x=>x.LanguageCode == languageId).SingleOrDefault().Label);
            
            //else, get the only one available regardless of languade code...
            if (a.DisplayName.LocalizedLabels.Count() == 1)
                attributesData.Add(a.LogicalName, a.DisplayName.LocalizedLabels[0].Label);
        }
            return attributesData;
    }

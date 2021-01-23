    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;
    using Microsoft.Xrm.Sdk.Metadata;
    
        public void GetOptionSet(string entityName, string fieldName, IOrganizationService service)
                {
                    RetrieveEntityRequest retrieveDetails = new RetrieveEntityRequest();
                    retrieveDetails.EntityFilters = EntityFilters.All;
                    retrieveDetails.LogicalName = entityName;
                    
                    RetrieveEntityResponse retrieveEntityResponseObj = (RetrieveEntityResponse)service.Execute(retrieveDetails);
                    EntityMetadata metadata = retrieveEntityResponseObj.EntityMetadata;
                    PicklistAttributeMetadata picklistMetadata = metadata.Attributes.FirstOrDefault(attribute => String.Equals(attribute.LogicalName, fieldName, StringComparison.OrdinalIgnoreCase)) as PicklistAttributeMetadata;
                    OptionSetMetadata options = picklistMetadata.OptionSet;
                    var optionlist = (from o in options.Options
                                       select new { Value = o.Value, Text = o.Label.UserLocalizedLabel.Label }).ToList();
    
                    //from here you can do anything you want now with the optionlist
                  
                }

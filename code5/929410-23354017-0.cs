        public static void GetOptionSet(string entityName, string fieldName, IOrganizationService service)
        {
            var attReq = new RetrieveAttributeRequest();
            attReq.EntityLogicalName = entityName;
            attReq.LogicalName = fieldName;
            attReq.RetrieveAsIfPublished = true;
            var attResponse = (RetrieveAttributeResponse)service.Execute(attReq);
            var attMetadata = (EnumAttributeMetadata)attResponse.AttributeMetadata;
            var optionList = (from o in attMetadata.OptionSet.Options
                select new {Value = o.Value, Text = o.Label.UserLocalizedLabel.Label}).ToList();
        }

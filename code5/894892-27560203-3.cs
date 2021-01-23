        public static T ToRelatedEntity<T>(this Entity rawEntity, string relatedAlias)
            where T:CrmEntity, new() 
            //CrmEntity is a base class I insert into my generated code 
            //to differentiate early-bound classes; you can use Entity
        {
            var result = new Entity(new T().LogicalName);
            
            foreach(var attribute in rawEntity.Attributes
                                        .Where(kvp=>kvp.Key
                                                  .StartsWith(relatedAlias + ".")))
            {
                var newName = attribute.Key.Replace(relatedAlias + ".", String.Empty);
                result[newName] = ((AliasedValue)attribute.Value).Value;
            }
            foreach(var formattedValue in rawEntity.FormattedValues
                                            .Where(kvp=>kvp.Key
                                                      .StartsWith(relatedAlias + ".")))
            {
                var newName = formattedValue.Key.Replace(relatedAlias + ".", String.Empty);
                result.FormattedValues[newName] = formattedValue.Value;
            }
            return result.ToEntity<T>();
        }
    //usage
    var query = new FetchExpression(fetchXml);
    var response = service.RetrieveMultiple(query);
    var contact = response.Entities[0].ToEntity<Contact>();
    var newCustom = response.Entities[0].ToRelatedEntity<new_custom>("nc");

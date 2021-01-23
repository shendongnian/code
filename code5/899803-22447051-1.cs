    ItemView view = new ItemView(10);
    // Create a definition for the extended property.
    ExtendedPropertyDefinition extendedPropertyDefinition = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.PublicStrings, "Engineer", MapiPropertyType.String);
    // Create a search filter the filters email based on the existence of the extended property.
    SearchFilter.Exists customPropertyExistsFilter = new SearchFilter.Exists(extendedPropertyDefinition);
    // Create a property set that includes the extended property definition.
    view.PropertySet = new PropertySet(BasePropertySet.IdOnly, ItemSchema.Subject, extendedPropertyDefinition);
            
    // Search the drafts folder with the defined view and search filter.
    FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Drafts, customPropertyExistsFilter, view);
            
    // Search the e-mail collection returned in the results for the extended property.
    foreach (Item item in findResults.Items)
    {
        Console.WriteLine(item.Subject);
        // Check whether the item has the custom extended property set.
        if (item.ExtendedProperties.Count > 0)
        {
            // Display the extended name and value of the extended property.
            foreach (ExtendedProperty extendedProperty in item.ExtendedProperties)
            {
                Console.WriteLine(" Extended Property Name: " + extendedProperty.PropertyDefinition.Name);
                Console.WriteLine(" Extended Property Value: " + extendedProperty.Value);
            }
        }
        else
        {
            Console.WriteLine(" This email does not have the 'Engineer' extended property set on it");
        }
    }

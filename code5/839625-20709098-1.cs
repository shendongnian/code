    foreach (SearchResult item in searchResultCollection)
    {
        foreach (string propKey in item.Properties.PropertyNames)
        {
            foreach (object property in item.Properties[propKey])
            {
                Console.WriteLine("{0} : {1}", propKey, property.ToString());
            }
        }
    }

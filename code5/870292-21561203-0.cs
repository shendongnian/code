    public string Bid(AdapterRequest adapterRequest)
    {
        string propertyChain = "Lead.Contact.ZipCode";
        string zipCode = ResolvePropertyChain(propertyChain.Split('.').ToList(), adapterRequest) as string;
        // ... assuming other logic exists here ...
    }
    public object ResolvePropertyChain(List<string> propertyChain, object source)
    {
        object propertyValue = null;
        if (source != null)
        {
            propertyValue = source.GetType().GetProperty(propertyChain[0]).GetValue(source, null);
            if (propertyValue != null && propertyChain.Count > 1)
            {
                List<string> childPropertyChain = new List<string>(propertyChain);
                childPropertyChain.RemoveAt(0);
                propertyValue = ResolvePropertyChain(childPropertyChain, propertyValue);
            }
        }
        return propertyValue;
    }

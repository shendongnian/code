    private IEnumerable<object> HandleChildItems()
    { 
        var itemsList = new List<Item>(); 
        GetChildItems(xmlnode, itemsList);
        // IEnumerable<T> is covariant
        return itemsList;    
    }
    
    private void GetChildItems(XMLnodeList nodeList, List<Item> itemsList)
    {
        // Here I recursively call the method to add the items to list
        foreach (xmlnode xn in nodeList)
        {
            if (xn.childnodes.count > 0)
            {
                GetChildItems(xn.childnodes, itemsList);
            }
            else
            {
                itemsList.Add(new Item { Code = "123", Itemtext = "xyz" });
            }
        }
    }

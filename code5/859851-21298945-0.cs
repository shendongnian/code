    //writing to xml file
    var doc = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
    var root = new XElement("Item");
    doc.Add(root);
    foreach (var inventory in inventories)
    {
    	var itemNode = new XElement("ItemName");
    	var itemAttribute = new XAttribute("ItemName", inventory.ItemName);
    	itemNode.Add(itemAttribute);
    	var itemQty = new XElement("ItemQuantity", inventory.Quantity);
    	itemNode.Add(itemQty);
    	var itemMaxQty = new XElement("ItemMaxQuantity", inventory.MaxQuantity);
    	itemNode.Add(itemMaxQty);
    	var itemState = new XElement("ItemState", inventory.ItemState);
    	itemNode.Add(itemState);
    	root.Add(itemNode);
    }
    doc.Save("Inventory.xml");
    
    //reading from xml file created by above codes to create List<Inventory> object
    var docFromFile = XDocument.Load("Inventory.xml");
    var inventoriesFromFile = (from inventory in docFromFile.Descendants("ItemName")
    					   select new Inventory
    								  {
    									  ItemName = inventory.Attribute("ItemName").Value,
    									  Quantity = inventory.Element("ItemQuantity").Value,
    									  MaxQuantity = inventory.Element("ItemMaxQuantity").Value,
    									  ItemState = inventory.Element("ItemState").Value
    								  }).ToList();
    								  
    //in the end you'll get variable inventories and inventoriesFromFile have same value

    var serializer = new XmlSerializer(typeof(List<Inventory>));
    var inventories = new List<Inventory>();
    inventories.Add(new Inventory
    {
    	ItemName = "Apple",
    	Quantity = "1",
    	MaxQuantity = "64",
    	ItemState = "PERFECT"
    });
    inventories.Add(new Inventory
    {
    	ItemName = "Sword",
    	Quantity = "1",
    	MaxQuantity = "1",
    	ItemState = "BROKEN"
    });
    //write to xml file
    using (var writer = new StreamWriter("inventory.xml"))
    {
    	serializer.Serialize(writer, inventories);
    }
    //read from xml file and generate List<Inventory>
    using (var reader = new StreamReader("inventory.xml"))
    {
    	//variable 'result' will contain the same value as 'inventories'
    	var result = (List<Inventory>)serializer.Deserialize(reader);
    }

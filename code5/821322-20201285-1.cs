    Inventory inventory = new Inventory(5);            
    inventory.Add("a");
    inventory.Add("b");
    inventory.Remove("a"); 
    var result = String.Join(", ", inventory);

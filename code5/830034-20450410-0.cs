    while (count > 0)
    {  
        Console.WriteLine("Enter the code :");
        Item item = searchItem(Convert.ToInt32(Console.ReadLine()));
        
        if(item == null){
             // Item not found
             Console.WriteLine("Item not found!");
        }else{
             // Item found
             SelectedItems itm = new SelectedItems();
             itm.item = item;
             Console.WriteLine("Enter the quantity :");
             itm.quantity = Convert.ToInt32(Console.Read());
             itm.subtotal = itm.item.unitprice * (Convert.ToDouble(itm.quantity));
             count--; // update count if success
        }
    }

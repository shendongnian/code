    while (count > 0)
     {  
        SelectedItems stm = new SelectedItems();
        Console.WriteLine("Enter the code :");
        Item im = searchItem(Convert.ToInt32(Console.ReadLine())); //You are returning an item here
        if (stm.item == null)    //You are checking an empty(null) instance of your selectedItems class that you
                                 // just created.
            Console.WriteLine("no item");
        else
        {
            Console.WriteLine("Enter the quantity :");
            stm.quantity = Convert.ToInt32(Console.Read());
            stm.subtotal = stm.item.unitprice * (Convert.ToDouble(stm.quantity));
            purchased.Add(stm);
        } 
        count--;
     }

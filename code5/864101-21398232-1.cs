    while (count > 0)
     {  
        SelectedItems stm = new SelectedItems();
        Console.WriteLine("Enter the code :");
        Item im = searchItem(Convert.ToInt32(Console.ReadLine()));
        if (im == null)   //Check if searchItem returned an object.
            Console.WriteLine("no item");
        else
        {
            stm.Item = im;  // Added item to your selected items
            Console.WriteLine("Enter the quantity :");
            stm.quantity = Convert.ToInt32(Console.Read());
            stm.subtotal = stm.item.unitprice * (Convert.ToDouble(stm.quantity));
            purchased.Add(stm);
        } 
        count--;
     }

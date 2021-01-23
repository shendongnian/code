    List<SelectedThing> selectedthing = new List<SelectedThing>();
    public void AddItems(List<Things> thing)
    {
        Console.Write("\nEnter Product ID : ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nEnter Quantity : ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        var item = thing.FirstOrDefault(i => i.ID == choice);
        if (item.ID == choice)
        {
            {
                var total = item.Price * quantity;
                selectedthing.Add(new SelectedProduct(this.ID = item.ID, this.Price = item.Price, this.Quantity = quantity, this.Name = item.Name));
                foreach (var items in selectedthing)
                {
                    Console.WriteLine("\nYou Selected {0} and {1} quantity.Total Is {2:C}\n", items.Name, quantity, total);
                }
            }
        }
        Console.WriteLine("\nWant To Add More Item..?? Press Y for Yes or E to End \n");
        Console.Write("\nYour Option  : ");
        string repeat = Console.ReadLine().ToLower();
        if (repeat == "y")
        {
            AddItems(thing);
        }
    }

    List<Listing> items = LoadListings(); //create a list of WordDef objects
    int checklast = 0;
    foreach (Listing myListing in items) //read in items from file
    {
        if (checklast == items.Count-1)
        {
            Console.Write(myListing.GetName());
        }
        else
        {
            //Console.WriteLine(myListing.GetName() + ": " +  myListing.GetDefinition());
            Console.Write(myListing.GetName() + " | ");
        }
        ++checklast;
    }

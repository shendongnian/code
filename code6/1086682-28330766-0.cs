    Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    
    void AddItem(int id)
    {
        foreach (Item i in ItemDatabase.Items)
            if (i.ID == id)
                {
                  if(!inventory.Keys.Contains(i)){iventory.Add(i, 0);}
                  inventory[i]+=1; //increment the amount;
                }
    }

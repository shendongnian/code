    public List<Item> tempAffected = new List<Item>();
    
    AddAffectedToDerived(item1, tempAffected);
    
    
    private AddAffectedToDerived(Item root, List<Item> derived)
    {
        if (root.AffectedItems != null)
        {
            foreach(Item itemX in root.AffectedItems)
            {
               AddAffectedToDerived(itemX);
            }
        }
    
        derived.Add(root);
    }

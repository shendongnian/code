    foreach (String pt in platypusTables)
    {
        menuItemSEND_Duckbills.EnableIfNot(pt,"Duckbill");
        menuItemSEND_Platypi.EnabledIfNot(pt,"Platypus");
        listBoxWork.Items.Add(pt);
    }
    //extention method, supposing a MenuItem class
    public static void EnableIfNot(this MenuItem menuItem, string table, string nameToSearch)
    {
         if(!menuItem.Enabled && table.IndexOf(nameToSearch)==0)
         {
                 menuItem.Enabled=true;
         }
    }

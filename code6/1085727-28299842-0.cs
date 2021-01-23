    foreach(var item in listA)
    {
        var itemInB = listB.FirstOrDefault(x=>x.ID==item.ID);
    
        if(itemInB!=null)
            item.WorkingID = itemInB.WorkongID
    
    }

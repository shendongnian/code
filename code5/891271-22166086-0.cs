    var x = 0;
    foreach(var item in ListA)
    {
        var list = ListN.Where(x=> x.ID == item.ID && x.Data != null).ToList();
           
        if(list.Any())
        {
           x = list.Min(y=>y.Data).Value;
           break;
        }    
    }

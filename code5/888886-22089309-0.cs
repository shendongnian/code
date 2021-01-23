    List<dynamic> productItems = new List<dynamic>();
    foreach (var item in services)
    {
        if (item.ProductItemTypeId == selectedItems.Select(s => s.ProductItemTypeId).FirstOrDefault())
        {
            productItems.Add(selectedItems.Where(w => w.ProductItemTypeId == item.ProductItemTypeId).FirstOrDefault());    
        }
        else
        {
            productItems.Add(item);
        }
    }

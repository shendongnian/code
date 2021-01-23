    var list = new List<Dimensions>();
    if (vm != null)
    {
        foreach (var item in vm)
        {
            //Not sure how you identify dupes, may need to change the filter here
            var duplicate = vm
                .Where(v => v.PeacesForItem == item.PeacesForItem);
         
            if (dupes.Any())
            {
                list.Add(new Dimension
                {
                     Width = item.Width,
                     Height = item.Height,
                     TypeId = item.TypeId,
                     PeacesForItem = item.PeacesForItem * 2;
                });
            }
        }
    }
    return list;

    infoMap.AsParallel().Select(
    map =>
    {
        var workItem = map.WorkItem;
        var parentInViews = viewMaps;
        var workbenchItem = map.WorkbenchItem;
        string LinkType = string.Empty;
        WorkItemLinkCollection linkedWorkItems = workItem.WorkItemLinkHistory;
        if (linkedWorkItems != null && linkedWorkItems.Count > 0)
            LinkType = linkedWorkItems[0].LinkTypeEnd.LinkType.ReferenceName;
        else if (workItem != null)
            LinkType = workItem.Store.WorkItemLinkTypes.LinkTypeEnds["Parent"].LinkType.ReferenceName;
        if (!string.IsNullOrEmpty(LinkType))
        {
            var viewMap = parentInViews.FirstOrDefault();
            if (viewMap != null)
            {
                var linkName =  LinkType;
                var childType = viewMap.ChildType;
                ILinkItem itm = Factory.BuildLinkItem(linkName, workbenchItem, workbenchItem);
                
                return new {item = itm, filter=true};
            }
        }
        return new {item = (ILinkItem)null, filter=false};
    })
    .Where(x=>x.filter)
    .Select(x=>x.item)
    .ToList();

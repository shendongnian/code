    public List<SelectListItem> GetStatusList(string PartRequestStatus)
    {
        List<SelectListItem> list = new System.Collections.Generic.List<SelectListItem>();
        list.Add(new SelectListItem() { Text = "New - Dispatch", Value = "New - Dispatch" });
        list.Add(new SelectListItem() { Text = "Exception - Warehouse", Value = "Exception - Warehouse" });
        list.Add(new SelectListItem() { Text = "HP Claim", Value = "HP Claim" });
    
        return list;
    }

    public List<SelectListItem> GetStatusList(string PartRequestStatus)
        {
            list.Add(new SelectListItem() { Text = "New - Dispatch", Value = "New - Dispatch", Selected = false });
            list.Add(new SelectListItem() { Text = "Exception - Warehouse", Value = "Exception - Warehouse", Selected = false });
            list.Add(new SelectListItem() { Text = "HP Claim", Value = "HP Claim", Selected = false });
   
        }

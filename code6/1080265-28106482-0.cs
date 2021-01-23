    IEnumerable<DrugInfoViewModel> Info = from a in db.Stocks.Where(
       r => r.SiteID == SiteID 
            && r.MachineID == MachineID 
            && EntityFunctions.TruncateTime(r.ExpiryDate) <= ExpiryDate)
       .ToList()
       select new DrugInfoViewModel()
       {
            ItemName = a.DrugBrand.Name,                           
            ItemBatchNo = a.BatchNo,
            ItemExpiryDate = (a.ExpiryDate == null ? null :
              Convert.ToDateTime(a.ExpiryDate).ToString("MM/dd/yyyy")),
                           Quantity = (int?)a.Qty
       };

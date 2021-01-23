    public class Model
    {
         public int CustomerID { get; set; }
         public int SelectedCustomer { get; set; }
         public IList<Pricelist> PriceList{get;set;}
         public IList<SelectListItem> PriceListSelectListItem{get;set;}
            {
                get
                {
                       var list = (from item in PriceList
                                select new SelectListItem()
                                {
                                    Text = item.customerID.ToString(CultureInfo.InvariantCulture),
                                    Value = item.selectedCustomer.ToString(CultureInfo.InvariantCulture)
                                }).ToList();
                    return list;
                }
                set{}
            } 
    
    }

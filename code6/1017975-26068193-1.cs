    public class ProductViewModel
    {
        public Product Model { get; set; }
        public IEnumerable<SelectListItem> Shops{ get; set; }
        public ProductViewModel()
        {
             GetShops();
        }
        public void GetShops()
        {
            Shops = new List<SelectListItem>();
            
            var collectionShops = GetShopsFromDatabase();
            Shops.AddRange(
                    collectionShops.Select(
                        contract =>
                        new SelectListItem
                        {
                            Text = contract.ShopDescription,
                            Value = contract.ShopID.ToString()
                        }));
        }
    }

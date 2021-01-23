    class SalesItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
    class SalesOrder
    {
        public void LoadItems()
        {
            List<SalesItem> SalesItems = new List<SalesItem>();
            SalesItem salesitem = new SalesItem()
            {
                Name = "Ball",
                Price = 12,
                Quantity = 1
            };
            SalesItems.Add(salesitem);
            salesitem = new SalesItem()
            {
                Name = "Ball",
                Price = 36,
                Quantity = 3
            };
            SalesItems.Add(salesitem);
            salesitem = new SalesItem()
            {
                Name = "Bat",
                Price = 50,
                Quantity = 1
            };
            SalesItems.Add(salesitem);
            salesitem = new SalesItem()
            {
                Name = "Ball",
                Price = 84,
                Quantity = 7            
            };
            SalesItems.Add(salesitem);
            salesitem = new SalesItem()
            {
                Name = "Bat",
                Price = 150,
                Quantity = 3
            };
            SalesItems.Add(salesitem);
            GroupOrders(SalesItems);
        }
        public List<SalesItem> GroupOrders(List<SalesItem> SalesItems)
        {
            var list = from item in SalesItems
                       group item by item.Name into orders
                       select new SalesItem
                       {
                           Name = orders.Key,
                           Price = orders.Sum(X=>X.Price),
                           Quantity = orders.Sum(X=>X.Quantity)
                       };
            List<SalesItem> resultList = new List<SalesItem>();
            foreach (SalesItem saleitem in list)
            {
                resultList.Add(saleitem);
            }
            return resultList;
        }
    }

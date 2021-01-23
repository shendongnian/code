        public ActionResult Shop()
        {
            ShopItem item = new ShopItem();
            return View(item);
        }
        [HttpPost]
        public ActionResult Shop(decimal Cost)
        {
            ShopItem item = new ShopItem();
            item.Cost = Cost;
            return View(item);
        }

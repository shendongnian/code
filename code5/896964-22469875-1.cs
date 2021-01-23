    public ActionResult Index()
    {
        List<Product> products = new List<Product>()
        {
           new Product{ Id=1, Name="Prod1", Stock=20 },
           new Product{ Id=2, Name="Prod2", Stock=10 },
        };
        foreach (var item in products)
        {
           if (item.StockList == null)
           {
               item.StockList = new List<SelectListItem>();
           }
           for (int i = 0; i <= item.Stock; i++)
           {
              var selectItem = new SelectListItem();
              selectItem.Text = i.ToString(); selectItem.Value = i.ToString();
              item.StockList.Add(selectItem);
            }
         }
         return View(products);
    }

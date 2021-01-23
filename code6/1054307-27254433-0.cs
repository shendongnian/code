     public ActionResult Index()
     {
          var model = db.Stores.OrderBy(s => s.StoreName)
                      .Select (s => new StoreDetails {
                           ID = s.ID,
                           Name = s.StoreName,
                           CountOfItems = s.Items.Count(),
                           CountOfBigType = s.Items.Count(x=>x.Size > 100) <--
                           //other counts if i can get this one working
                           });
          return View(model);
     }

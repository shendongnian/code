    public ViewResult Index()
        {      
                return View();
        }
        
        public ActionResult Customers_Read([DataSourceRequest]DataSourceRequest request)
        {
            using (var db = new CimDataContext())
            {
                IQueryable<Customer> customers = db.Customers;
                DataSourceResult result = customers.ToDataSourceResult(request);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

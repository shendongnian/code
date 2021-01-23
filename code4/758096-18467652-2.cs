    public MyController:Controller {
         IProduct<Product> service = new MyRepository();
         
           public ActionResult Index() {
                var prods = service.GetProducts();
                return View(prods) ;
    }
    }

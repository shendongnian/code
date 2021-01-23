    public HelloController : ServiceStackController 
    {
        public void Index(string name) 
        {
            using (var svc = AppHostBase.ResolveService<HelloService>(HttpContext.Current))
            {
               ViewBag.GreetResult = svc.Get(name).Result;
               return View();
            }
        }        
    }

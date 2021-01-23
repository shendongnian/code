    public HelloController : ServiceStackController 
    {
        public void Index(string name) 
        {
            using (var svc = base.ResolveService<HelloService>())
            {
               ViewBag.GreetResult = svc.Get(name).Result;
               return View();
            }
        }        
    }

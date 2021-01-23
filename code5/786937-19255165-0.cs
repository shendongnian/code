    public HelloController : ServiceStackController 
    {
        public void Index(string name) 
        {
            using (var helloService = AppHostBase.ResolveService<HelloService>())
            {
               ViewBag.GreetResult = helloService.Get(name).Result;
               return View();
            }
        }        
    }

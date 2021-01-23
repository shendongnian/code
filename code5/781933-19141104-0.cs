    private DossiersDBEntities DossiersDb=new DossiersDBEntities();
    private ClientsDBEntities ClientsDb = new ClientsDBEntities();
    public ActionResult Create()
            {
                var ListClients = from c in ClientsDb.Clients
                                select new
                                {
                                    c.CL_N,
                                    c.CL_NOM
                                };
                ViewData["ListClients"] = new SelectList(ListClients, "CL_N", "CL_NOM");
                return View();

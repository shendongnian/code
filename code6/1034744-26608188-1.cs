    private JustSpecItAppContext db = new JustSpecItAppContext();
    
    // GET: Actors1
        public ActionResult Index(int actorId)
        {
            var query= db.Actors.Where(x => x.Id == actorId).ToList())
    
            return View(query);
        }

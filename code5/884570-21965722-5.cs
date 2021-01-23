    //GET: /Entidade/Create
     public ActionResult Create()
        {
            ViewBag.PaisSelectList = new SelectList(db.Paises, "Id", "Nome");
            return View();
        }
    // POST: /Entidade/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Entidade entidade)
    {
        if (ModelState.IsValid)
        {
            db.Entidades.Add(entidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.PaisSelectList = new SelectList(db.Paises, "Id", "Nome", entidade.PaisId);
        return View(entidade);
    }

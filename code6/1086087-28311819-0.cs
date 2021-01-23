    [HttpPost]
    public ActionResult AgregarActividad(Actividades act)
    {
    var db = new WTMEntities();
    
            var proyectos = (from pro in db.Proyecto
                             select new
                             {
                                 Id = pro.Id,
                                 Nombre = pro.Nombre
                             }).ToList();
            ViewData["Projects"] = new SelectList(proyectos.Select(i => i.Nombre));
    
        if (ModelState.IsValid)
        {
            var actividad = db.Set<Actividades>();
            actividad.Add(act);
            db.SaveChanges();
    
            return View();
        }
        else
        {
            return View();
        }
    }

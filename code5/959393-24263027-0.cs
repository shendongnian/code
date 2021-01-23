    using (ISession session = NHIbernateSession.OpenSession())
    {
        var index = session.Query<Transport>().ToList();
        List<SelectListItem> items = new List<SelectListItem>();
        foreach (var car in index)
        {
            items.Add(new SelectListItem() 
              { Text = car.Modelis.model_name, Value = car.Modelis.Id.ToString() }); 
        }
        ViewBag.Modeliai = items;
        return View(index);
    }

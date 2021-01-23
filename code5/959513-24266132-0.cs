    using (ISession session = NHIbernateSession.OpenSession())
        {                
          var item = session.Query<CarModel>().ToList();
          ViewBag.Modas = item;
          // Either set the model like .... ViewData.Model = new YOUR_MODEL_CLASS();
         // OR return your model by view constructor like.. return View(new YOUR_MODEL_CLASS());
          return View();
        }

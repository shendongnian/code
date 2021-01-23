    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include="ID,Name,User,Password")] Ad ad,FormCollection form)
            {
                string selectedValue = form["selectedOne"].ToString();
                if (ModelState.IsValid)
                {
                    db.Ad.Add(ad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                foreach(var item in ad.Type)
                {
                  if(item.Value == selectedValue)
                  {
                     item.Selected = true;
                  }
                }
    
                return View(ad);
            }

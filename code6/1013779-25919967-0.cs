    public ActionResult Index()
        {
                        //  var result = db.Items.Select(i => i.GeoName).Distinct().OrderBy(n => n);
             Viewer model = new Viewer();
             model = (from x in db.Items
                     select new Viewer
                     {
                       GeoPSRType = x.FieldName
                      }).Distinct().FirstOrDefault().OrderBy(x => x.SomeField);
                         
            return View(model);
        }

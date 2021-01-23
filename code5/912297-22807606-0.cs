     public ActionResult Movie()
            {
                MyModel model = new MyModel();
                return View(model);
    
            }
     [HttpPost]
            public ActionResult Movie(Current mod)
            {
                MyModel car = new MyModel();
                ////if (mod.FormAction.Equals("Done"))
                ////{
    
                    mod.Headers = mod.Headers;
                    mod.Ids = mod.Ids;
                    mod.Contents = mod.Contents;
                    car.Currents.Add(mod);
                    UpdateModel(car);
                    return View(car);
                ///}
    
                ////return View();
            }

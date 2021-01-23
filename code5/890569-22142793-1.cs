     public ActionResult Welcome(string name, int numTimes = 1)
        {
          var model = new List<ModelClass>
                {
                    new ModelClass{name="name",numTimes=1}
                };
            return View(model);
        }

        public ActionResult Update(Demo model)
    {
        var item = db.Items.Where(item => item.Number == model.Number).First();
        if (item.Type=="EXPENSIVE")
        {
            return PartialView("name Partial", someViewModel);
        }
    }

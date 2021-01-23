    [HttpPost]
    public ActionResult Index(PropListVM model)
    {
        foreach (var prop in model.Props)
        {
            string s = prop.Name;
            //Do cool somethings
        }
        // return or redirect now
        //If we are returning the posted model back to the form, 
        //reload the Props property.
        model.Props = GetPropsFromSomeWhere();
        return View(model);
    }

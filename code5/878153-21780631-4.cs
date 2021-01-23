    [Route("ControllerExample/Edit/{idVar1}/Brands/{idVar2}", Order = 1)]
    public ActionResult ActionResultExample(int idVar1, int idVar2)
    {
        var objectForView= ObjectController.Get(idVar1, idVar2);
        return View("ActionResultExample", objectForView);
    }
    [Route("ControllerExample/Edit/{idVar1}/Brands", Order = 2)]
    public ActionResult ActionResultExampleWithoutDefaults(int idVar1)
    {
        ...
        var idVar2 = getDefaultVar2();
        return RedirectToAction("ActionResultExample", //redirects to ControllerExample/Edit/idVar1/Brands?idVar2=idVar2 instead of ControllerExample/Edit/idVar1/Brands/idVar2
            new {idVar1= idVar1, idVar2 = idVar2 });
    }

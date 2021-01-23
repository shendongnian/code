    [Route("ControllerExample/Edit/{idVar1}/Brands/{idVar2?}")]
    public ActionResult ActionResultExample(int idVar1, int? idVar2 = null)
    {
        var idVar2Int = !idVar2.HasValue ? getDefaultVar2() : idVar2.Value;
        var objectForView= ObjectController.Get(idVar1, idVar2Int);
        return View("ActionResultExample", objectForView);
    }

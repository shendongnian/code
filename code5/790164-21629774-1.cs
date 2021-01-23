    public ActionResult SomeAction(MyViewModel vm)
    {
        var data = SomeRepository.GetData(vm.Parameter1, vm.Parameter2, ...);
        return Json(data);
    }

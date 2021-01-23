    public ActionResult Action() 
    {
          MyViewModel vm = new MyViewModel();
          vm.MeltFurnace1 = something;
          return View("YourViewName", vm);
    }

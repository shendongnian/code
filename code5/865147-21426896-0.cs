    [HttpPost]
    public ActionResult SaveStatement(User currentUser, FormCollection statement, string    ViewModelName)
    {
      Assembly assembly = typeof(SomeKnownType).Assembly;
      Type type = assembly.GetType(ViewModelName);
      object ViewModel = Activator.CreateInstance(type);
      if (!TryUpdateModel(ViewModel, statement.ToValueProvider()))
      {
         //some another actions
      }
      return View(ViewModelName, ViewModel);
    }

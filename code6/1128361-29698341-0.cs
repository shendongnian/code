    protected ActionResult WithID(int? arg, Func<int, ActionResult> logic)
    {
      if (arg == null)
      {
        return RedirectToAction("Index");
      }
    
      return logic(arg.Value);
    }

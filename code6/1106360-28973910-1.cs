    public async Task<ActionResult> Home()
    { 
      var model = new Model();
      var t1 = Helper.A("Jared", 9001, model);
      var t2 = Helper.B("Jared", model);
    
      await Task.WhenAll(new [] { t1, t2 });
    
      return View("Home", model);
    }
    
    public static class Helper
    {
      public static async Task A(string username, int power, Model model)
      {
        /* do A things to the model */ 
      }
      public static async Task B(string username, Model model)
      {
        /* do B things to the model */ 
      }
    }

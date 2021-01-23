    public static class Logger
    {
      public static void Log(string message)
      {
        //logging logic here..
      }
    }
    public ActionResult Documents(DocumentsForRequirementViewModel model)
    {
      Logger.Log("GET action on Documents");
      //bla bla
    }

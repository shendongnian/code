      public ActionResult HandleCommand(string comand)
      {
        CommandAction Comand = commandHandler[comand] ?? new CommandAction(method, new HttpStatusCodeResult(404));
        Comand.DoSomthing();
        return Comand.Result;
       }

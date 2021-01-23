    public ActionResult Action(string param, CancellationToken token)
    {
         // do your thing
         if (token.IsCancellationRequested)
         {
             // abort
         }
         // do your thing
    }

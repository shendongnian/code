    public ActionResult UpdateAdsBudgets(string budget, string[] Ids)
    {
        ServerResult serverResult = null;
        try
        {
            int numOfSuccess = 0;
            for (int i = 0; i < Ids.Length; i++)
            {
                serverResult = UpdateAdBudget(Ids[i]);
                if (serverResult.ServerResultState == ServerResultState.SUCCESS)
                {
                    numOfSuccess++;
                }
             }
         }
    
         return Json(YOUR_DATA); 
     }

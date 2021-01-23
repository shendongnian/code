    var firstRes = resource.First();
    if (firstRes != null) 
    {
         var user = firstRes.AssignedADUser
         if (user != null)
         {
             // Do your normal work.
         }
         else
         {
             // Log a message here
         }
    }
    else
    {
         // Log a message here 
    }

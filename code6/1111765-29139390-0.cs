     protected override IEnumerator Lerp()
     {
         if (IsFirst)
         {
             while (!Game.GameInstance.GameOver)
             {
                 if (Recording)
                 {
                     Debug.Log("SubMethod");
                     yield return StartCoroutin(base.Lerp());    // See here                                             
                 }
                 else
                 {
                     yield return null;
                    
                 }
             }
         }
        // Rest of code
     }

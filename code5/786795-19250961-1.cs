    var thread = new Thread((ThreadStart)delegate
            {
             While(true)
               {
                 TSM.ModelObjectEnumerator myEnum = null;
                 myEnum = new TSM.UI.ModelObjectSelector().GetSelectedObjects();
                 while (myEnum.MoveNext())
                  {
                      if (myEnum.Current != null)
                     {....}
                  }
    
                  Thread.Sleep(1000);
               }
             }
        thread.Start();

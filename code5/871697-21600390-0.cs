    using (var scope = TransactionHelper.Instance)
    {
     var process = true;
     var aMessage = "";
     try
     {
       //Enter you code and functions here
       //Whenever you find a piece of code to be working incorrectly, Raise an error
       if(!someCode(blabla))
          throw new Exception("This someCode quited on me!");
       //Whenever your code does what it needs to do, end with a commit
       scope.Commit();
     }
     catch(Exception ex) //Catch whatever exception might occur
     {
      scope.FullRollBack(); 
      aMessage = ex.Message;
      process = false;
     }
     finally 
     {
      //only here you will use messageboxes to explain what did occur during the process
      if (process)
        MessageBox.Show("Succesfully Committed!");
      else
        MessageBox.Show(string.Format("Rollback occurred, exception Message: {0}"
                        , aMessage);
     }
    }

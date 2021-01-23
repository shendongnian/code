    Action action = () => { //call SaveImageAsCorrectFormat }
    try {
      action();
    }
    catch
    {
      try {
        action();
      catch (Exception exception) {
        //handle
      }
    }

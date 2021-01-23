    private async void PostData()
    {
      try
      {
        var taskObj = await UserProfile.getUserProfile().getUserProfileFromServer();
        //PoolCircle.UserProfile.ProfileResponseJson userObj = taskObj;
        setDataContext(taskObj);
      }
      catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

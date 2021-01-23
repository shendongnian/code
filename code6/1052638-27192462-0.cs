    [HttpPost]
    public ActionResult Add(ViewModel model)
    {
        try
        {
            // update the achievement
            model.achievementItem.EventDate = DateTime.Now;
            model.achievementItem.StaffID = CurrentUser.StaffID;
            bool success = SIMSClient.ClientFunctions.AddAchievement(GlobalVariables.networkstuff, GlobalVariables.testAuth, model.achievementItem);
            return Content(success.ToString());
        }
        catch
        {
            return Content(false.ToString());;
        }
    }

    [HttpPost]
    public ActionResult DelayReminder(string reminderId)
    {
    ReminderStatus rs = new ReminderStatus();
    
    
    rs.BaseProps.RequesterUserInfo.UserID = SessionManager.Current.CurrentUser.UserID;
    
    
    ReminderServiceHelper.InsertNewStatus(Convert.ToInt32(reminderId), rs);
    
    return GetLawDetail(apptype); // Problem...
    }

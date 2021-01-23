    public JsonResult Get(string machineName)
        {
            int NotificationsNumber = NotificationsFunctions.CheckForNotifications(machineName);
            NotificationsResult result = new NotificationsResult();
            if(NotificationsNumber > 0)
            {
                result.Result = "true";
            }else
            {
                result.Result = "false";
            }
           
            return Json(result);
        }

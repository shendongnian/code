        List<dynamic> notificationList = new List<object>();
        var userNotification = new { Text = "Here is some text!", Url = "http://www.google.com/#q=notifications" };
        notificationList.Add(userNotification);
        foreach(dynamic notification in notificationList)
        {
            string value = notification.Text;
        }  

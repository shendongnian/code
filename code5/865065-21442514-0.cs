    var sendNotificationRequest = (HttpWebRequest)WebRequest.Create(Notification URL);
    sendNotificationRequest.Method = "POST";
    const string tileMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                            "<wp:Notification xmlns:wp=\"WPNotification\">" +
                            "<wp:Tile>" +
                            "<wp:BackgroundImage>" + "</wp:BackgroundImage>" +
                            "<wp:Count>" + "1" + "</wp:Count>" +
                            "<wp:Title>" + "Completed" + "</wp:Title>" +
                            "<wp:BackBackgroundImage>" + "</wp:BackBackgroundImage>" +
                            "<wp:BackTitle>" + "</wp:BackTitle>" +
                            "<wp:BackContent>" + "</wp:BackContent>" +
                            "</wp:Tile> " +
                            "</wp:Notification>";
    byte[] notificationMessage = Encoding.Default.GetBytes(tileMessage);
    sendNotificationRequest.ContentLength = notificationMessage.Length;
    sendNotificationRequest.ContentType = "text/xml";
    sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", "token");
    sendNotificationRequest.Headers.Add("X-NotificationClass", "1");
    try
    {
      using (Stream requestStream = sendNotificationRequest.GetRequestStream())
      {
        requestStream.Write(notificationMessage, 0, notificationMessage.Length);
      }
      var response = (HttpWebResponse)sendNotificationRequest.GetResponse();
      string notificationStatus = response.Headers["X-NotificationStatus"];
      string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
      string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];
    }
    catch
    {}

        Boolean bsandbox = true;
        string p12fileName =AppDomain.CurrentDomain.BaseDirectory + "yourCert.p12";
        string p12password = "1234";
        string deviceID1 = "2909b25e0c699b2dc4864b4b9f719e67aac7e0fab791a72a086ffb788ba28f6a"; //
        string msg = "This is the message sent at : ";
        string alert = "Hello world at " + DateTime.Now.ToLongTimeString();
        int badge = 1;
        string soundstring = "default";
        var payload1 = new NotificationPayload(deviceID1, alert, badge, soundstring);
        payload1.AddCustom("custom1", msg); 
        var notificationList = new List<NotificationPayload> { payload1 };
        var push = new PushNotification(bsandbox, p12fileName, p12password);
        var rejected = push.SendToApple(notificationList);`

     public ActionResult ios()
        {
            var certi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificatesgit.p12");
            var appleCert = System.IO.File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificatesgit.p12"));
            ApnsConfiguration apnsConfig = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Production, appleCert, "password");
            string message = string.Empty;
            var apnsBroker = new ApnsServiceBroker(apnsConfig);
            apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {
                aggregateEx.Handle(ex =>
                {
                    if (ex is ApnsNotificationException)
                    {
                        var notificationException = (ApnsNotificationException)ex;
                        var apnsNotification = notificationException.Notification;
                        var statusCode = notificationException.ErrorStatusCode;
                        var inner = notificationException.InnerException;
                        message = "IOS Push Notifications: Apple Notification Failed: ID=" + apnsNotification.Identifier + ", Code=" + statusCode + ", Inner Exception" + inner;
                    }
                    else
                    {
                        message = "IOS Push Notifications: Apple Notification Failed for some unknown reason : " + ex.InnerException;
                    }
                    return true;
                });
            };
            apnsBroker.OnNotificationSucceeded += (notification) =>
            {
                message = "IOS Push Notifications: Apple Notification Sent!";
            };
            apnsBroker.Start();
            try
            {
                string deviceToken = "4e16e1439d7f1a342ed5a8c92bf029503107c7a2bc3b92b794b22665affcf99c";
                apnsBroker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = deviceToken,
                    Payload = JObject.Parse("{\"aps\":{\"badge\":7}}")
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            apnsBroker.Stop();
            return View(message);
        }

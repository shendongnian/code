    using Consumer.Mobile.Services;
    using Consumer.Mobile.Services.PushNotification;
    using UIKit;
    namespace Consumer.Mobile.iOS.PushNotification
    {
        public class iOSPushNotificationRegister : IPushNotificationRegister
        {
            public override void ExtractTokenAndRegister()
            {
                const UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
        }
    }

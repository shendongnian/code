    [assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
    [assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
    // Gives the app permission to register and receive messages.
    [assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]
    // Needed to keep the processor from sleeping when a message arrives
    [assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
    [assembly: UsesPermission(Name = "android.permission.RECEIVE_BOOT_COMPLETED")]
    namespace Consumer.Mobile.Droid.PushNotification
    {
        public class PushNotificationRegister : IPushNotificationRegister
        {          
            public override void ExtractTokenAndRegister()
            {
                string senders = AndroidConfig.GCMSenderId;
                Intent intent = new Intent("com.google.android.c2dm.intent.REGISTER");
                intent.SetPackage("com.google.android.gsf");
                intent.PutExtra("app", PendingIntent.GetBroadcast(MainActivity.Context, 0, new Intent(), 0));
                intent.PutExtra("sender", senders);
                MainActivity.Context.StartService(intent);
            }
          
        }
    }

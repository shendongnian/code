    using Android.App;
    using Android.Content;
    using Android.Graphics;
    using Android.Media;
    using Android.OS;
    using Android.Support.V4.App;
    using Consumer.Mobile.Infra;
    using Consumer.Mobile.Services.PushNotification;
    using Java.Lang;
    using XLabs.Ioc;
    using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
    namespace Consumer.Mobile.Droid.PushNotification
    {
        [Service]
        public class MyIntentService : IntentService
        {
            private readonly ILogger _logger;
            private readonly IPushNotificationService _notificationService;
            private readonly IPushNotificationRegister _pushNotificationRegister;
            public MyIntentService()
            {
                _logger = Resolver.Resolve<ILogger>();
                _notificationService = Resolver.Resolve<IPushNotificationService>();
                _pushNotificationRegister = Resolver.Resolve<IPushNotificationRegister>();
            }
            static PowerManager.WakeLock _sWakeLock;
            static readonly object Lock = new object();
            public static void RunIntentInService(Context context, Intent intent)
            {
                lock (Lock)
                {
                    if (_sWakeLock == null)
                    {
                        // This is called from BroadcastReceiver, there is no init.
                        var pm = PowerManager.FromContext(context);
                        _sWakeLock = pm.NewWakeLock(
                        WakeLockFlags.Partial, "My WakeLock Tag");
                    }
                }
                _sWakeLock.Acquire();
                intent.SetClass(context, typeof(MyIntentService));
                context.StartService(intent);
            }
            protected override void OnHandleIntent(Intent intent)
            {
                try
                {
                    Context context = this.ApplicationContext;
                    string action = intent.Action;
                    if (action.Equals("com.google.android.c2dm.intent.REGISTRATION"))
                    {
                        HandleRegistration(context, intent);
                    }
                    else if (action.Equals("com.google.android.c2dm.intent.RECEIVE"))
                    {
                        HandleMessage(context, intent);
                    }
                }
                finally
                {
                    lock (Lock)
                    {
                        //Sanity check for null as this is a public method
                        if (_sWakeLock != null)
                            _sWakeLock.Release();
                    }
                }
            }
            private void HandleMessage(Context context, Intent intent)
            {
               
                Intent resultIntent = new Intent(this, typeof(MainActivity));
                TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
                var c = Class.FromType(typeof(MainActivity));
                stackBuilder.AddParentStack(c);
                stackBuilder.AddNextIntent(resultIntent);
                string alert = intent.GetStringExtra("Alert");
                int number = intent.GetIntExtra("Badge", 0);
                var imageUrl = intent.GetStringExtra("ImageUrl");
                var title = intent.GetStringExtra("Title");
                Bitmap bitmap = GetBitmap(imageUrl);
                PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);
                NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
                    .SetAutoCancel(true) // dismiss the notification from the notification area when the user clicks on it
                    .SetContentIntent(resultPendingIntent) // start up this activity when the user clicks the intent.
                    .SetContentTitle(title) // Set the title
                    .SetNumber(number) // Display the count in the Content Info
                    .SetSmallIcon(Resource.Drawable.Icon) // This is the icon to display
                    .SetLargeIcon(bitmap)
                    .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                    .SetContentText(alert); // the message to display.
                // Build the notification:
                Notification notification = builder.Build();
                // Get the notification manager:
                NotificationManager notificationManager =
                    GetSystemService(Context.NotificationService) as NotificationManager;
                // Publish the notification:
                const int notificationId = 0;
                notificationManager.Notify(notificationId, notification);
            }
            private void HandleRegistration(Context context, Intent intent)
            {
                var token = intent.GetStringExtra("registration_id");
                _logger.Info(this.Class.SimpleName, "Received Token : " + token);
                if (_pushNotificationRegister.ShouldSendToken(token))
                {
                    var uid = Android.Provider.Settings.Secure.GetString(MainActivity.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
                    _notificationService.AddPushToken(token, DeviceUtils.GetDeviceType(), uid);
                }
            }
            private Bitmap GetBitmap(string url)
            {
                try
                {
                    System.Net.WebRequest request =
                        System.Net.WebRequest.Create(url);
                    System.Net.WebResponse response = request.GetResponse();
                    System.IO.Stream responseStream =
                        response.GetResponseStream();
                    return BitmapFactory.DecodeStream(responseStream);
                }
                catch (System.Net.WebException)
                {
                    return null;
                }
            }
        }
    }

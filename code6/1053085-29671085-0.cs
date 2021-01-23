    class Flurry
    {
        public const string ApiKeyValue = "YOUR_API_KEY";
        private readonly IntPtr _flurryClass;
        private readonly IntPtr _flurryOnStartSession;
        private readonly IntPtr _flurryOnEndSession;
        private readonly IntPtr _flurrySetContinueSessionMillis;
        public Flurry()
        {
            _flurryClass = JNIEnv.FindClass("com/flurry/android/FlurryAgent");
 
            _flurryOnStartSession = JNIEnv.GetStaticMethodID(_flurryClass, "onStartSession", "(Landroid/content/Context;Ljava/lang/String;)V");
            _flurryOnEndSession = JNIEnv.GetStaticMethodID(_flurryClass, "onEndSession", "(Landroid/content/Context;)V");
            _flurrySetContinueSessionMillis = JNIEnv.GetStaticMethodID(_flurryClass, "setContinueSessionMillis", "(J)V"); 
        }
        public void OnStartActivity(Activity activity)
        {
            try
            {
                JNIEnv.CallStaticVoidMethod(_flurryClass, _flurryOnStartSession, new JValue(activity), new JValue(new Java.Lang.String(ApiKeyValue)));
            }
            catch (Exception) { }
        }
        public void OnStopActivity(Activity activity)
        {
            try
            {
                JNIEnv.CallStaticVoidMethod(_flurryClass, _flurryOnEndSession, new JValue(activity));
            }
            catch (Exception) { }
        }
        public void setContinueSessionMillis(long millis)
        {
            try
            {
                JNIEnv.CallStaticVoidMethod(_flurryClass, _flurrySetContinueSessionMillis, new JValue(millis));
            }
            catch (Exception) { }
        }
 
    }

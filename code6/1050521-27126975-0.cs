    public class YourAppClass : Application
    {
        public override void OnCreate()
        {
            AndroidEnvironment.UnhandledExceptionRaiser += HandleAndroidException;
        }
    }

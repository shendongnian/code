    public class MyClass
    {
        private Delegate _backPressedDelegate;
        private static readonly Type _hardwareButtonsType;
        private static readonly EventInfo _backPressedEvent;
        static MyClass()
        {
            _hardwareButtonsType = Type.GetType(
                "Windows.Phone.UI.Input.HardwareButtons, " +
                "Windows, Version=255.255.255.255, Culture=neutral, " +
                "PublicKeyToken=null, ContentType=WindowsRuntime");
            _backPressedEvent = _hardwareButtonsType.GetTypeInfo().GetDeclaredEvent("BackPressed");
        }
        public void Start()
        {
            // Register event
            Action<object, object> callback = OnBackKeyPressed;
            var callbackMethodInfo = callback.GetMethodInfo();
            _backPressedDelegate = callbackMethodInfo.CreateDelegate(_backPressedEvent.EventHandlerType, this);
            _backPressedEvent.AddMethod.Invoke(null, new object[] { _backPressedDelegate });
        }
        public void Stop()
        {
            // Unregister event
            _backPressedEvent.RemoveMethod.Invoke(null, new object[] { _backPressedDelegate });
            _backPressedDelegate = null;
        }
        private void OnBackKeyPressed(object sender, dynamic args)
        {
            // Handle event
            if (!args.Handled)
                args.Handled = DoIt(args.Handled);
        }
    }

    public class MyClass
    {
        private object _backPressedToken;
        private static readonly Type _hardwareButtonsType;
        private static readonly EventInfo _backPressedEvent;
        static MyClass()
        {
            _hardwareButtonsType = Type.GetType(
                "Windows.Phone.UI.Input.HardwareButtons, " +
                "Windows, Version=255.255.255.255, Culture=neutral, " +
                "PublicKeyToken=null, ContentType=WindowsRuntime");
            
            if (_hardwareButtonsType != null)
                _backPressedEvent = _hardwareButtonsType.GetRuntimeEvent("BackPressed");
        }
        public void Start()
        {
            // Register event
            Action<object, object> callback = OnBackKeyPressed;
            var callbackMethodInfo = callback.GetMethodInfo();
			var backPressedDelegate = callbackMethodInfo.CreateDelegate(_backPressedEvent.EventHandlerType, this);
			_backPressedToken = _backPressedEvent.AddMethod.Invoke(null, new object[] { backPressedDelegate });
        }
        public void Stop()
        {
            // Unregister event
			_backPressedEvent.RemoveMethod.Invoke(null, new [] { _backPressedToken });
			_backPressedToken = null; 
        }
        private void OnBackKeyPressed(object sender, dynamic args)
        {
            // Handle event
            if (!args.Handled)
                args.Handled = DoIt(args.Handled);
        }
    }

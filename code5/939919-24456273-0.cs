    public static class Extensions
    {
        #region Public Methods and Operators
        public static Stopwatch ClickButton(this Form form, string controlName)
        {
            var controls = form.Controls.Find(controlName, true);
            if (controls.Any())
            {
                var control = controls[0] as Button;
                if (control != null)
                {
                    MethodInfo mi = typeof(Button).GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
                    var stopWatch = Stopwatch.StartNew();
                    mi.Invoke(
                        control,
                        new object[]
                        {
                            EventArgs.Empty
                        });
                    return stopWatch;
                }
            }
            throw new ApplicationException("Control not found or of invalid Type");
        }
        public static Delegate ConvertDelegate(Delegate originalDelegate, Type targetDelegateType)
        {
            return Delegate.CreateDelegate(targetDelegateType, originalDelegate.Target, originalDelegate.Method);
        }
        public static object GetControlProperty<T>(this Form form, string controlName, string propertyName) where T : class
        {
            var controls = form.Controls.Find(controlName, true);
            if (controls.Any())
            {
                var control = controls[0];
                PropertyInfo pi = typeof(T).GetProperty(propertyName);
                return pi.GetValue(control, null);
            }
            throw new ApplicationException("Control not found or of invalid Type");
        }
        public static void ObserveControlEvents<T>(this Form form, string controlName, string eventName, Action<object, object> action) where T : class
        {
            var controls = form.Controls.Find(controlName, true);
            if (controls.Any())
            {
                var control = controls[0] as T;
                if (control != null)
                {
                    EventInfo ei = typeof(T).GetEvent(eventName);
                    if (ei != null)
                    {
                        Delegate handler = ConvertDelegate(action, ei.EventHandlerType);
                        ei.AddEventHandler(control, handler);
                    }
                }
            }
        }
        public static void ObserveGrid(this Form form, string controlName, string eventName, Action<object, object> action)
        {
            var controls = form.Controls.Find(controlName, true);
            if (controls.Any())
            {
                var control = controls[0] as DataGridView;
                if (control != null)
                {
                    EventInfo ei = typeof(DataGridView).GetEvent(eventName);
                    if (ei != null)
                    {
                        Delegate handler = ConvertDelegate(action, ei.EventHandlerType);
                        ei.AddEventHandler(control, handler);
                    }
                }
            }
        }
        public static void SetControlProperty<T>(this Form form, string controlName, string propertyName, object value) where T : class
        {
            var controls = form.Controls.Find(controlName, true);
            if (controls.Any())
            {
                var control = controls[0];
                PropertyInfo pi = typeof(T).GetProperty(propertyName);
                pi.SetValue(control, value, null);
            }
        }
        public static void SetFormProperty(this Form form, string controlName, object value)
        {
            var controls = form.Controls.Find(controlName, true);
            if (controls.Any())
            {
                var control = controls[0];
                PropertyInfo pi = typeof(Control).GetProperty("Text");
                pi.SetValue(control, value, null);
            }
        }
        #endregion
    }

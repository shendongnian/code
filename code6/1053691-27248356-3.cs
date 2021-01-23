    class Program
    {
        static void Main(string[] args)
        {
            var fc = new TestCheckbox();
            fc.CheckedChanged += (sender, e) =>
            {
                int i = 0;
            };
    
            // 'CheckedChanged' event is not raised.
            fc.SetValueFor(x => x.Checked = true, "CheckedChanged");
            // 'CheckedChanged' event it raised.
            fc.Checked = false;
        }
    }
    
    class TestCheckbox
    {
        private bool _checked;
    
        public event EventHandler CheckedChanged;
    
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this, EventArgs.Empty);
                }
            }
        }
    }
    
    public static class PropertySetter
    {
        private static readonly object locker = new object();
    
        public static void SetValueFor<T>(this T obj, Action<T> action, string eventName)
        {
            lock (locker)
            {
                try
                {
                    // Get event handlers.
                    Type type = obj.GetType();
                    var eventInfo = type.GetEvent(eventName);
                    var fieldInfo = type.GetField(eventName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    var multicastDelegate = fieldInfo.GetValue(obj) as MulticastDelegate;
                    Delegate[] delegates = multicastDelegate.GetInvocationList();
    
                    // Remove event handlers.
                    foreach (var item in delegates)
                    {
                        eventInfo.RemoveEventHandler(obj, item);
                    }
    
                    try
                    {
                        action(obj);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        // Restore event handlers.
                        foreach (var item in delegates)
                        {
                            eventInfo.AddEventHandler(obj, item);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

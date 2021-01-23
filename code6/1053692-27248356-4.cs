    class Program
    {
        static void Main(string[] args)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.CheckedChanged += (sender, e) =>
            {
                if (!sender.CanHandleEvent("CheckedChanged")) return;
                int i = 0;
            };
    
            checkBox.SetValueFor(x => x.Checked = true, "CheckedChanged");
            checkBox.Checked = false;
        }
    }       
    
    public static class PropertySetter
    {
        private static readonly object locker = new object();
    
        public static object CurrentObject { get; private set; }
    
        public static string CurrentEventName { get; private set; }
    
        public static void SetValueFor<T>(this T obj, Action<T> action, string eventName)
        {
            lock (locker)
            {
                CurrentObject = obj;
                CurrentEventName = eventName;
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
                    CurrentObject = null;
                    CurrentEventName = null;
                }
            }
        }
    
        public static bool CanHandleEvent(this object obj, string eventName)
        {
            return !(object.ReferenceEquals(obj, CurrentObject) == true && CurrentEventName.Equals(eventName) == true);
        }
    }

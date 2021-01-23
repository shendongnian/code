    public static class FormExtension
    {
       public static void CopyEvent(this Form form, Control src, string fieldName, string eventName, Control dest)
       {
           EventHandlerList events = (EventHandlerList)typeof(Control)
                                      .GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance)
                                      .GetValue(src, null);
           object key = typeof(Control).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
           EventInfo evInfo = typeof(Control).GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance);
           Delegate del = events[key];
           if (del != null)
           {
               Delegate d = Delegate.CreateDelegate(evInfo.EventHandlerType, form, del.Method);
               MethodInfo addHandler = evInfo.GetAddMethod();
               Object[] addHandlerArgs = { d };
               addHandler.Invoke(dest, addHandlerArgs);
           }
       }
    }

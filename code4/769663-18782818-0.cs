    FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static| BindingFlags.NonPublic);
    object obj = f1.GetValue(panel1);
    PropertyInfo pi = panel1.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
    EventHandlerList list = (EventHandlerList)pi.GetValue(panel1, null);
    list.RemoveHandler(obj, list[obj]);
 

    public static void AddMethodToComoBox(EventHandler MetodName, ComboBox cbm)
    {
       cm.SelectedIndexChanged -= MethodName;
       cm.SelectedIndexChanged += MethodName;
    }
    public static void RemoveMethodToComoBox(EventHandler MetodName, ComboBox cbm)
    {
       cbm.SelectedIndexChanged -= MetodName;//won't never throw exception
    }

    public static void GetClass<T>(string ActionString) where  T : ICommonInterface, new()
    {
       var c = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.BaseType == typeof(ICommonInterface)).First();
            FieldInfo de = c.GetType().GetField(ActionString);
            var obj = (T)de.GetValue(c);
            obj.TriggerSomeAction();
    }

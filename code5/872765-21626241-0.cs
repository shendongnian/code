    var switchType = activity.GetType();
    var prop = typeof(Switch<>).GetProperty("Cases", System.Reflection.BindingFlags.Public 
                | System.Reflection.BindingFlags.Instance); //move it outside of the method and use the same property for every time you call the method since it's performance expansive.
    bool isSwitch = (switchType.IsGenericType && switchType.GetGenericTypeDefinition() == typeof(Switch<>));
    if (isSwitch)
    {
            IDictionary dictionary = prop.GetValue(activity,null) as IDictionary;
            foreach (var item in dictionary.Values)
            {
                ProcessActivity(item, dataSets, context);
            }
    }

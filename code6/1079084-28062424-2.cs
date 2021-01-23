    var controlName = 'yourcontrolName from db';
    var propertyName = 'your property name from db';
    object value = //the deserialized value from db;
    var control = findControlByName(controlName);
    control.GetType().GetProperty(propertyName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).SetValue(control, value, new object[] { });

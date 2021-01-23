    Properties p = new Properties();
    Type t = p.GetType(); //or use typeof(Properties)
    
    int value = 1;
    foreach (String valueToSet in valuesList) {
       var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance; //because they're private properties
       t.GetProperty(valueToSet, bindingFlags).SetValue(p, value++); //where p is the instance of your object
    }
    

    [CustomPermission("Allowed")]
    public void GetData()
    {
       Type t = typeof(thisClass);
       var mi = t.GetMethod("GetData");
       var attr = mi.GetCustomAttribute<CustomPermission>();
       // now attr contains your CustomPermission
       if (attr.Name == "Allowed") 
       {
           //only comes here if permisson is allowed
           //logic for db 
       }
    }

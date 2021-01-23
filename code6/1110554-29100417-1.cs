    [CustomPermission("Allowed")]
    public void GetData()
    {
       var mi = MethodInfo.GetCurrentMethod();
       var attr = mi.GetCustomAttribute<CustomPermission>();
       // now attr contains your CustomPermission
       if (attr.Name == "Allowed") 
       {
           //only comes here if permisson is allowed
           //logic for db 
       }
    }

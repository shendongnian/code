    public object GetDeepPropertyValue(object instance, string path){
      var pp = path.Split('.');
      Type t = instance.GetType();
      foreach(var prop in pp){
        PropertyInfo propInfo = t.GetProperty(prop);
        if(propInfo != null){
          instance = propInfo.GetValue(instance, null);
          t = propInfo.PropertyType;
        }else {
          return null;
        }
      }
      return instance;
    }
    string res = (GetDeepPropertyValue(root, "Member.User.Name") ?? "").ToString();

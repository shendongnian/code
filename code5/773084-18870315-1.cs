    public object GetDeepPropertyValue(object instance, string path){
      var pp = path.Split('.');
      Type t = instance.GetType();
      foreach(var prop in pp){
        PropertyInfo propInfo = t.GetProperty(prop);
        if(propInfo != null){
          instance = propInfo.GetValue(instance, null);
          t = propInfo.PropertyType;
        }else throw new ArgumentException("Properties path is not correct");
      }
      return instance;
    }
    string res = GetDeepPropertyValue(root, "Member.User.Name").ToString();

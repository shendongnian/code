    private static string GetProperyName(ObjectGraph obj) {
      return obi._propertyName;
    }
    
    public string PropertyName
    {
       get
       {
            // ermmm, not sure why this Select can access _propertyName???
            var parents = string.Join("/", Parents.Select(GetProperyName));
            return string.Format("{0}/{1}", parents, _propertyName);
        }
    }

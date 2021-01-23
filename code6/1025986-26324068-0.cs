    public static void VisitAnnotatedFields<TAttribute>(
      MonoBehaviour target,
      Action<FieldInfo, TAttribute> closure)
      where TAttribute : Attribute
    {
        IEnumerable<FieldInfo> fieldInfos = target.GetAllFields();
        foreach( var iField in fieldInfos ){
          object[] customAttributes = iField.GetCustomAttributes(false);
          foreach( var jAttr in customAttributes ){
            if( jAttr.GetType().IsAssignableFrom(typeof(TAttribute)) ){
              closure.Invoke(iField, (TAttribute) jAttr);
            }
          }
        }
    }

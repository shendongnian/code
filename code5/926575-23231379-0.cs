    public bool IsNull<T>(this T source, string path)
    {
         var props = path.Split('.');
         var type = source.GetType();
         var currentObject = type.GetProperty(prop[0]).GetValue(source);
         if (currentObject == null) return true;
         foreach (var prop in props.Skip(1))
         {
              var currentValue = currentObject.GetType()
                    .GetProperty(prop)
                    .GetValue(currentObject);
             if (currentValue == null) return true;
         }
         return false;
    }

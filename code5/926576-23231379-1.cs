    public static bool IsNull<T>(this T source, string path)
    {
         var props = path.Split('.');
         var type = source.GetType();
         var currentObject = type.GetProperty(props[0]).GetValue(source);
         if (currentObject == null) return true;
         foreach (var prop in props.Skip(1))
         {
              currentObject = currentObject.GetType()
                    .GetProperty(prop)
                    .GetValue(currentObject);
             if (currentObject == null) return true;
         }
         return false;
    }

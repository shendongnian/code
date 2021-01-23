    static void PopulateFrom(this BaseClass dest, BaseClass source) //extension method will not modify legacy code and can be added to the any static class
    {
         var properties = source.GetType().GetProperties(public only);
         foreach (var pi in properties)
            if (pi.CanRead && pi.CanWrite)
              pi.SetValue(dest, pi.GetValue(source, null), null); //this will work only for classes inherited from BaseClass
    }

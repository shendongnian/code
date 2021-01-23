    public static T SetProperties<T>(this T source, HttpContext context)
    {
         var properties = typeof(T)
                 .GetProperties(BindingFlags.Instance | BindingFlags.Public);
         var  values = context.Request.QueryString;
         foreach (var prop in properties)
         {
             if (values.AllKeys.Contains(prop.Name))
             {
                 prop.SetValue(source,values[prop.Name]);
             }
         }
    }

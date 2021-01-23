    public static T Init<T>(T TObject)
    {
      var properties = TObject.GetType().GetProperties();
      foreach (var property in properties)
      {
         if (property.PropertyType.Equals(typeof(string)))
         {
             property.SetValue(TObject, string.Empty);
         }
         else if (property.PropertyType.Equals(typeof(int)))
         {
             property.SetValue(TObject, 0);
         }
         else if (property.PropertyType.Equals(typeof(DateTime)))
         {
             property.SetValue(TObject, DateTime.UtcNow);
         }
      }
      return TObject;
    }

    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    public static class Extensions
    {
      public static NameValueCollection ToNameValueCollection(this dynamic dynamicObject)
      {
        var nameValueCollection = new NameValueCollection();
        foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(dynamicObject))
        {
          string value = propertyDescriptor.GetValue(dynamicObject).ToString();
          nameValueCollection.Add(propertyDescriptor.Name, value);
        }
        return nameValueCollection;
      }
    }

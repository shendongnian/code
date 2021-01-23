    var myEntity = new MyEntity();
    var value = "The data";
    var columnNumber = 1;
    
    PropertyInfo propertyInfo = MyEntity.GetType().GetProperty(string.Format("Col_{0}", columnNumber));
    propertyInfo.SetValue(myEntity, Convert.ChangeType(value, propertyInfo.PropertyType), null);

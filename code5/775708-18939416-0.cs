    GoldAverages Gold = new GoldAverages();
    Type gType = Gold.GetType();
    IList<PropertyInfo> properties = new List<PropertyInfo>(gType.GetProperties());
    
    foreach (PropertyInfo property in properties)
    {
        string propertyName = property.Name;
        string propertyValue = property.GetValue(Gold, null);
        LblSummery.Text += propertyName + " : " + propertyValue + "|";
    }

    GoldAverages Gold = new GoldAverages();
    Type gType = Gold.GetType();
    IList<PropertyInfo> properties = new List<PropertyInfo>(gType.GetProperties());
    
    StringBuilder sb = new StringBuilder();
    foreach (PropertyInfo property in properties)
    {
        string propertyName = property.Name;
        string propertyValue = property.GetValue(Gold, null);
        sb.Append(propertyName + " : " + propertyValue + " | ");
    }
    LblSummery.Text = sb.ToString();

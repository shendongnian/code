    var result = HttpUtility.ParseQueryString(strResponse);
    Type myType = GetType();
    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
    foreach (PropertyInfo prop in props)
    {
        try
        {
            prop.SetValue(this,
                Convert.ChangeType(result[prop.Name], prop.PropertyType, CultureInfo.InvariantCulture),
                null);
        }
        catch (InvalidCastException)
        {
            //skip missing values
        }
        catch (Exception ex)
        {
            //something went wrong with parsing the result
            new Database().Base.AddErrorLog(ex);
        }
    }

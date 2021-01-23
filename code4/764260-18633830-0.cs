    public BaseInfo GetPropertyByName(Employee employee, string propertyName)
    {
        var propInfo = typeof(Employee).GetProperty(propertyName);
        return propInfo.GetValue(employee) as BaseInfo;
    }

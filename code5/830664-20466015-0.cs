    public static object ConvertDataRowToObject(object Object, DataTable DataTable)
    {
        try
        {
            if (DataTable.Rows.Count > 0)
            {
                DataRow DataRow = DataTable.AsEnumerable().FirstOrDefault();
                if (DataRow != null)
                {
                    Type ObjectType = Object.GetType();
                    //Get public properties
                    System.Reflection.PropertyInfo[] _propertyInfo =
                         ObjectType.GetProperties();
                    foreach (System.Reflection.PropertyInfo _property in _propertyInfo)
                    {
                        _property.SetValue(Object, (DataRow[_property.Name.ToString()] is System.DBNull ? null : DataRow[_property.Name.ToString()]), null);
                    }
                    return Object;
                }
                else return null;
            }
            else
                return null;
        }
        catch (Exception excp)
        {
            Common.WriteErrorLog(excp.Message);
            return null;
        }
    }

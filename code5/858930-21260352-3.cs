    public static DataTable EnumToDataTable<T>(IEnumerable<T> l_oItems)
    {
        var firstItem = l_oItems.FirstOrDefault();
        if (firstItem == null)
            return new DataTable();
        DataTable oReturn = new DataTable(TypeDescriptor.GetClassName(firstItem));
        object[] a_oValues;
        int i;
        var properties = TypeDescriptor.GetProperties(firstItem);
        foreach (PropertyDescriptor property in properties)
        {
            oReturn.Columns.Add(property.Name, BaseType(property.PropertyType));
        }
        //#### Traverse the l_oItems
        foreach (T oItem in l_oItems)
        {
            //#### Collect the a_oValues for this loop
            a_oValues = new object[properties.Count];
            //#### Traverse the a_oProperties, populating each a_oValues as we go
            for (i = 0; i < properties.Count; i++)
                a_oValues[i] = properties[i].GetValue(oItem);
            //#### .Add the .Row that represents the current a_oValues into our oReturn value
            oReturn.Rows.Add(a_oValues);
        }
        //#### Return the above determined oReturn value to the caller
        return oReturn;
    }

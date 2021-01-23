    ColumnSpec computed; // your instance.
    Type myType = typeof(ColumnSpec); The reflected Type of ColumnSpec.
    string combinedString = "";
    foreach (FieldInfo field in myType.GetFields()) // this enumerates all public fields.
    {
        if (field.FieldType == typeof(string)) // only for strings
        {
            string fieldValue = field.GetValue(computed); // extract the value.
            combinedString += fieldValue;
        }
    }

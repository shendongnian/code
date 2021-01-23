    string dateTimeType = "System.Nullable<System.DateTime>";
    
    foreach (PropertyMetadata property in ModelMetadata.Properties) {
        bool isNullableDateTime = property.TypeName.Equals(dateTimeType);
    
        if( isNullableDateTime )
        {
            // do something
        }
    }

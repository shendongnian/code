    string nullableDateTimeType = "System.Nullable<System.DateTime>";
    
    foreach (PropertyMetadata property in ModelMetadata.Properties) {
        bool isNullableDateTime = property.TypeName.Equals(nullableDateTimeType);
    
        if( isNullableDateTime )
        {
            // do something
        }
    }

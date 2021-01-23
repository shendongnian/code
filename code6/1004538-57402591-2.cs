    public class AlternativeValueJsonConverter<TEnum> : JsonConverter where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        public override bool CanConvert( Type objectType )
        {
            // we can only convert if the type of object matches the generic type specified
            return objectType == typeof( TEnum );
        }
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( objectType == typeof(TEnum) )
            {
                // cycle through the enum values
                foreach(var item in (TEnum[])Enum.GetValues( typeof( TEnum ) ) )
                {
                    // get the AlternativeValueAttribute, if it exists
                    var attr = item.GetType().GetTypeInfo().GetRuntimeField( item.ToString() )
                        .GetCustomAttribute<AlternativeValueAttribute>();
                    
                    // if the JsonValue property matches the incoming value, 
                    // return this enum value
                    if (attr != null && attr.JsonValue == reader.Value.ToString())
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if( value.GetType() == typeof( TEnum ) )
            {
                // cycle through the enum values
                foreach( var item in (TEnum[])Enum.GetValues( typeof( TEnum ) ) )
                {
                    // if we've found the right enum value
                    if (item.ToString() == value.ToString() )
                    {
                        // get the attribute from the enum value
                        var attr = item.GetType().GetTypeInfo().GetRuntimeField( item.ToString() )
                            .GetCustomAttribute<AlternativeValueAttribute>();
                        if( attr != null)
                        {
                            // write out the JsonValue property's value
                            serializer.Serialize( writer, attr.JsonValue );
                        }
                    }
                }
            }
        }
    }

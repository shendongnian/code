    IJsonValue idValue = itemObject.GetNamedValue("id");
    if ( idValue.ValueType == JsonValueType.Null)
    {
        // is Null
    }
    else if (idValue.ValueType == JsonValueType.String)
    {
        string id = idValue.GetString();
    }

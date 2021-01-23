    using ServiceStack.Text;
    JsConfig<DateTime>.SerializeFn = SerializeAsUKDate;
    // Also, if you need to support nullable DateTimes:
    JsConfig<DateTime?>.SerializeFn = SerializeAsNullableUKDate;
    public static string SerializeAsUKDate(DateTime value)
    {
        // or whatever you prefer to specify the format/culture
        return value.ToString("dd/MM/yyyy");
    }
    public static string SerializeAsNullableUKDate(DateTime? value)
    {
        return value.HasValue ? SerializeAsUKDate(value.Value) : null;
    }

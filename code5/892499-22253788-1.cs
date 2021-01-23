    JsConfig<DateTime>.DeSerializeFn = DeSerializeAsUKDate;
    public static DateTime DeSerializeAsUKDate(string value)
    {
        // date parsing logic here
        // ServiceStack.Text.Common.DateTimeSerializer has some helper methods you may want to leverage
    }

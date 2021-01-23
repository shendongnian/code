    public static Tuple<object, object> UnpackUnknownTuple(object tuple)
    {
        var item1Property = tuple.GetType().GetProperty("Item1");
        var item2Property = tuple.GetType().GetProperty("Item2");
        return Tuple.Create(
            item1Property.GetValue(tuple, null), 
            item2Property.GetValue(tuple, null));
    }
    public override void WriteJson(
        JsonWriter writer,
        object value,
        JsonSerializer serializer)
    {
        var obj = value as IEnumerable;
        var tuples = obj.Cast<object>.Select(UnpackUnknownTuple);
        object[][] dataArray = (from dp in tuples 
                                select new[] { dp.Item1, dp.Item2 }).ToArray();
        var ser = new JsonSerializer();
        ser.Serialize(writer, dataArray);
    }

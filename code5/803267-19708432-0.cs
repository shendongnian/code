    JsConfig<DateTime>.DeSerializeFn = time =>
    {
      if (!IsInCorrectDateFormat(time))
        throw new System.Runtime.Serialization.SerializationException(BadDateTime);
      
      return ServiceStack.Text.Common.DateTimeSerializer.ParseDateTime(time);
    };

    public class YouCustomClassConverter : JavaScriptConverter
    {
      public override object Deserialize(IDictionary<string, object> dictionary, Type type,                      JavaScriptSerializer serializer)
      {
          throw new NotImplementedException();
      }
    
      public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
      {
          throw new NotImplementedException();
      }
    
       //and first you need register type, which you want Deserialize
       public override IEnumerable<Type> SupportedTypes
       {
          get { return new[] { typeof(YouCustomClass ) }; }
       }
    
    }
    
    //and then example of using JavaScriptSerializer with custom converter
    var ser = new JavaScriptSerializer();
    ser.RegisterConverters(new JavaScriptConverter[] { new YouCustomClassConverter() });
    try
    {
         YouCustomClass obj = ser.Deserialize(jsonString);
    }

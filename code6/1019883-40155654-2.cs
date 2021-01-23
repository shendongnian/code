      StringBuilder sb = new StringBuilder();
      StringWriter sw = new StringWriter(sb);
    
      using(JsonWriter textWriter = new JsonTextWriter(sw))
      {
         var serializer = new JsonSerializer();
         serializer.Serialize(textWriter, yourObject);
      }

     public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
          var jToken = JToken.Load(reader);
          if (jToken.HasValues)
          {
            var jObject = JObject.Load(jToken.CreateReader());
            var xmlBlob = jObject.GetValue(XMLKEY);
            if (xmlBlob != null)
            {
              var delphiObject = CoreFactory.CrossPlatformProperties.DeserializeDelphiObject(xmlBlob.Value<string>());
              return delphiObject;
            }
          }
          return serializer.Deserialize(jToken.CreateReader());
        }

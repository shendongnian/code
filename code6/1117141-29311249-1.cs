       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
          var jToken = JToken.Load(reader);
          if (jToken.HasValues)
          {
            var xmlBlob = jToken[XMLKEY];
            if (jToken.First.Path == XMLKEY)
            { 
              var delphiObject = CoreFactory.CrossPlatformProperties.DeserializeDelphiObject(xmlBlob.Value<string>());
              return delphiObject;
            }
          }
          return serializer.Deserialize(jToken.CreateReader());
        }

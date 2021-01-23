    private void AddRemoveSerializedProperties(JObject jObject, MahMan baseContract)
       {
           jObject.AddFirst(....);
            foreach (KeyValuePair<string, JToken> propertyJToken in jObject)
            {
                if (propertyJToken.Value.Type != JTokenType.Object)
                    continue;
                JToken nestedJObject = propertyJToken.Value;
                PropertyInfo clrProperty = baseContract.GetType().GetProperty(propertyJToken.Key);
                MahMan nestedObjectValue = clrProperty.GetValue(baseContract) as MahMan;
                if(nestedObj != null)
                    AddRemoveSerializedProperties((JObject)nestedJObject, nestedObjectValue);
            }
        }

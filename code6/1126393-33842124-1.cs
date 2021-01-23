    using System.Globalization;
    public static void ParseMongoDBISODate()
    {
        // Json Writer Settings - To avoid problems with 10Gen types
        var jsonSettings = new JsonWriterSettings() { OutputMode = JsonOutputMode.Strict };
    
        // Mapping string to a dynamic json object
        JObject mappedJson = JObject.Parse(jsonObject.ToJson(jsonSettings));
    
        // Trying to extract property values out of the object
        foreach (Field field in _configuration.Fields)
        {
            // Checking for JToken Type
            JTokenType objType = fieldData.Type;
    
            // Sanity Check for NULL Values of properties that do exist
            if (objType == JTokenType.Null)
            {
                fieldValue = String.Empty;
            }
            // Checking for Arrays (that need to be serialized differently)
            else if (objType == JTokenType.Array)
            {
                String[] valuesArray = fieldData.Select(t => t.Value<String>().Replace(_configuration.ListDelimiter, String.Empty).Replace(_configuration.Delimiter, String.Empty)).ToArray();
    
                fieldValue = String.Join(_configuration.ListDelimiter, valuesArray);
            }
            // Checking for specific MongoDB "_id" situation
            else if (objType == JTokenType.Object && field.Name.Equals("_id"))
            {
                fieldValue = fieldData.ToObject<String>(); // Value<ObjectId> ().ToString ();
            }
            else
            {
                try // it's a bad way but you can set fieldValue as a DateTime
                {
                    //JTokenType.Date
                    DateTime mongoDBISODate = DateTime.Parse(fieldData.Value<String>(), null, DateTimeStyles.RoundtripKind);
                    fieldValue = mongoDBISODate;
                }
                catch (Exception)
                {
                    // Reaching Attribute Value as "String" (if nothing else worked)
                    fieldValue = fieldData.Value<String>();
                }
            }
        }
    }

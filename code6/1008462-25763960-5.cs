            public class MyCustomConverter : JsonConverter
    		{
    			public override bool CanConvert(Type objectType)
    			{
    				return objectType == typeof(ObservableCollectionExt);
    			}
    
    			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    			{
    				ObservableCollectionExt result = new ObservableCollectionExt();
    				string type = null;
    				int i;
    				while (reader.Read())
    				{
    					if (reader.TokenType == JsonToken.PropertyName)
    						type = reader.Value.ToString();
    					else if (reader.TokenType == JsonToken.EndObject)
    						return result;
    					else if (!string.IsNullOrEmpty(type) && reader.Value != null)
    					{
    						switch (type)
    						{
    							case "mydata1":
    								{
    									result.MyData1 = reader.Value.ToString();
    									break;
    								}
    							case "mydata2":
    								{
    									result.MyData2 = reader.Value.ToString();
    									break;
    								}
    							case "elements":
    								{
    									if (int.TryParse(reader.Value.ToString(), out i))
    										result.Add(i);
    									break;
    								}
    						}
    					}
    				}
    				return result;
    			}
    
    			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    			{
    				ObservableCollectionExt o = (ObservableCollectionExt)value;
    
    				writer.WriteStartObject();
    
    				writer.WritePropertyName("mydata1");
    				writer.WriteValue(o.MyData1);
    
    				writer.WritePropertyName("mydata2");
    				writer.WriteValue(o.MyData2);
    
    				writer.WritePropertyName("elements");
    				writer.WriteStartArray();
    				foreach (var val in o)
    					writer.WriteValue(val);
    				writer.WriteEndArray();
    
    				writer.WriteEndObject();
    			}
    		}

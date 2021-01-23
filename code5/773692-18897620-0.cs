       public class TableEditCustomBinder : IModelBinder
            {
                public object BindModel(ControllerContext controllerContext,
                                ModelBindingContext bindingContext)
                {
                    var incomingData = bindingContext.ValueProvider.GetValue("data").AttemptedValue;
                    JObject root = JObject.Parse("{\"root\": " + incomingData + "}");
                    JArray items = (JArray)root["root"];
                    JObject item;
                    JToken jtoken;
                    List<TableData> data = new List<TableData>();
                    string action="" , newValue="", oldValue="", dataType;
                    double time=0;
                    for (int i = 0; i < items.Count; i++)
                    {
                        item = (JObject)items[i];
                        jtoken = item.First;
                        while (jtoken != null)//loop through columns
                        {
                            dataType = ((JProperty)jtoken).Name.ToString().ToLower();
                            
                            switch (dataType)
    	                    {
                                case "time":
                                    time = Convert.ToDouble(((JProperty)jtoken).Value);
                                    break;
                                case "newvalue":
                                    newValue = ((JProperty)jtoken).Value.ToString();
                                    break;
                                case "oldvalue":
                                    oldValue = ((JProperty)jtoken).Value.ToString();
                                    break;
                                case "action":
                                    action = ((JProperty)jtoken).Value.ToString();
                                    break;
    		                    default:
                                    break;
    	                    }
                             jtoken = jtoken.Next;
                        }
                        if (time != 0) {
                            data.Add(new TableData(time, oldValue));
                            data[data.Count-1].NewValue = newValue;
                            data[data.Count-1].Action = action;
                        }
                       
                    }
                    
                    return data;
                    
                }
            }
            [HttpPost]
            public object TableEdit(string server, string tag, [ModelBinder(typeof(TableEditCustomBinder))] List<TableData> data)      
            {         
                //Use data the way you want
            }

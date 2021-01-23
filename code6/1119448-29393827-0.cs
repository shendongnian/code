    if (tokenType is JArray)
                {
                    var arr = JsonConvert.DeserializeObject(message) as JArray;
                    foreach (var item in arr)
                    {
                        var agentParameter = item.ToObject<Foo>();
                        agentParameter.JSON = item.ToString();
                        result.Add(agentParameter);
                    }
                }

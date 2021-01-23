    if (tokenType is JArray)
                    {
                        var arr = JsonConvert.DeserializeObject(message) as JArray;
                        foreach (var item in arr)
                        {
                            try
                            {
                                var agentParameter = item.ToObject<Foo>();
                                agentParameter.JSON = item.ToString();
                                result.Add(agentParameter);
                            }
                            catch (Exception)
                            {
                                LogProvider.Error(string.Format("Failed to Deserialize message. Message text: \r\n {0}", item.ToString()));
                            }
                        }
                    }

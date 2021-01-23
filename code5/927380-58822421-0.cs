               T jsonResponse = new T();
                    var settings = new JsonSerializerSettings
                    {
                        DateParseHandling = DateParseHandling.DateTimeOffset,
                        NullValueHandling = NullValueHandling.Ignore,
                    };
                    var jRslt = response.Content.ReadAsStringAsync().Result;
                    if (jsonResponse.GetType() == typeof(myProject.Models.myModel))
                    {
                        var dobj = JsonConvert.DeserializeObject<myModel[]>(jRslt);
                        var y = dobj.First();
                        var szObj = JsonConvert.SerializeObject(y);
                        JsonConvert.PopulateObject(szObj, jsonResponse, settings);
                    }
                    else
                    {
                        JsonConvert.PopulateObject(jRslt, jsonResponse);
                    }

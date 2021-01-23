    private static void Main(string[] args)
            {
                var listing = new Listing()
                    {
                        Id = 1,
                        Address = new Address()
                            {
                                Id = 1,
                                Street1 = "sdfsdfsdfsdfsd",
                                Contact = new Contact()
                                    {
                                        FirstName = "ert34253453",
                                        Id = 5,
                                        Created = DateTime.Now
                                    }
                            }
                    };
    
    
                var json = JsonConvert.SerializeObject(listing);
    
                var jss = new JavaScriptSerializer();
                var o = jss.Deserialize<Dictionary<string, object>>(json);
    
                var additionalParameters = new Dictionary<string, string>();
                BuildVariablesList(o, "", additionalParameters);
            }
    
    
    
            private static string AppendToPathString(string path, object part, string delimiter = ".")
            {
                return path.Trim().Length == 0 ? part.ToString() : path + delimiter  + part;
            }
    
            public static void BuildVariablesList(object obj, string path, Dictionary<string, string> result)
            {
                if (obj is ArrayList)
                {
                    var arrayObj = obj as ArrayList;
                    for (var i = 0; i < arrayObj.Count; i++)
                    {
                        BuildVariablesList(arrayObj[i], AppendToPathString(path, i), result);
                    }
                }
                else if (obj is Dictionary<string, object>)
                {
                    var dictObject = obj as Dictionary<string, object>;
                    foreach (var entry in dictObject)
                    {
    
                        if (entry.Value is Dictionary<string, object>)
                        {
                            BuildVariablesList(entry.Value as Dictionary<string, object>, AppendToPathString(path, entry.Key), result);
                        }
                        else if (entry.Value is ArrayList)
                        {
                            BuildVariablesList(entry.Value as ArrayList, AppendToPathString(path, entry.Key), result);
                        }
                        else
                        {
                           if (entry.Value != null)
                           {
                               result.Add(AppendToPathString(path, entry.Key), entry.Value.ToString());
                           }
                           else
                           {
                               result.Add(AppendToPathString(path, entry.Key), string.Empty);
                           }
    
    
                        }
                    }
                }
    
            }

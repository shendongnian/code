           List<string> layers = new List<string>();
           var dict = jss.Deserialize<Dictionary<string, dynamic>>(json);
                    foreach (Dictionary<string,dynamic> key in dict["layers"])
                    {
                        key.TryGetValue("name", out layersDic);
                        layers.Add(layersDic);
                    }

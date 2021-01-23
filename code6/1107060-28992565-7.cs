            if (retData.data.IsJsonArray())
                foreach (var obj in retData.data.AsJsonArray())
                    if (obj.IsJsonObject())
                    {
                        var map = obj.AsJsonObject();
                        if (map.ContainsKey("username") && map.ContainsKey("password"))
                            Console.WriteLine(map["password"]);
                    }

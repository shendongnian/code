    var entities = JsonConvert.DeserializeObject<List<dynamic>>(saveBundle.SelectToken("entities").ToString());
         
            foreach (var entity in entities)
            { 
                JObject objEntityAspect = entity["entityAspect"];
                JToken objEntityState = objEntityAspect["entityState"];
                if (objEntityState.Value<string>() == "Modified")
                {
                    // make a post with the instance id
                }
                entity.Remove("entityAspect");
            }

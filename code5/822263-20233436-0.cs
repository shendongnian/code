    private GeoCoordinate ParserJSON(string pJSON)
            {   
                //Se o JSON está presente
                if (pJSON != null)
                {
                    try
                    {
                        //Faz a conversão (parse) para um tipo jObject
                        JObject jObj = JObject.Parse(pJSON);
    
                        //Le o objeto da lista inteira
                        JArray results = jObj["results"] as JArray;
    
                        JToken firstResult = results.First;
                        JToken location = firstResult["geometry"]["location"];
                        
                        GeoCoordinate coord = new GeoCoordinate()
                        {
                            Latitude = Convert.ToDouble(location["lat"].ToString()),
                            Longitude = Convert.ToDouble(location["lng"].ToString())
                        };
    
    
                    }
                    catch 
                    {
                        ///todo: if para verificar conexão
                        MessageBox.Show("Verify your network connection!");
                    }
                    
                }
                return null;
            }

    public ActionResult Chart()
            {
               //Get data from DB, items is list of objects:
               //1. DisplayText - (string) - chart columns names (equals "labels")
               //2. Value - (int) - chart values (equals "data")   
               var items = _Layer.GetData().ToList(); 
                
               //check if data exists
               if (items.Any())
                {
                    string color = "#3c8dbc";
                    Dataset ds = new Dataset
                    {
                        label = string.Empty,
                        fillColor = color,
                        pointColor = color,
                        strokeColor = color
                    };
                    
                    var data = items.Select(x => x.Value).ToList();
                    ds.data.AddRange(data);
                    model.datasets.Add(ds);
    
                    var labels = items.Select(x => x.DisplayText).ToList();
                    model.labels = labels;
                }
    
                var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
    
                return PartialView("_Chart", json);
            }

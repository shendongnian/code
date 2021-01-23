    SeriesCollection collection = new SeriesCollection();
    
    collection.Series.Add(new Serie() { Name = "Target", Data = { 1, 2, 3 } });
    collection.Series.Add(new Serie() { Name = "Alarm", Data = { 1, 2, 3 } });
    collection.Series.Add(new Serie() { Name = "Actual", Data = { 1, 2, 3 } });
    
    System.Web.Script.Serialization.JavaScriptSerializer jSearializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    string seriesStr = jSearializer.Serialize(collection);
    Output:
    {"Series":[{"Name":"Target","Data":[1,2,3]},
               {"Name":"Alarm","Data":[1,2,3]},
               {"Name":"Actual","Data":[1,2,3]}
              ]}

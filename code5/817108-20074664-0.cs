    List<object> modified_listofstrings = new List<object>();
    List<object> series = new List<object>();
    System.Web.Script.Serialization.JavaScriptSerializer jSearializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    
    for (int i = 0; i < id_series_before_offset.Count; i++)
    {
    	var xmlAttributeCollection = id_series_before_offset[i].Attributes;
    	if (xmlAttributeCollection != null)
    	{
    		...
    		series_name = QPR_webService_Client.GetAttributeAsString(sessionId, resulted_series_id, "name", "");
    		var serie = new {name = series_name, data = new List<float>()};
    		...
    
    		for (int j = 0; j < value.Count; j++)
    		{
    			...
    			if (xmlAttributeCollection_for_period != null)
    			{
    				...
    				period_final_value = float.Parse(action.Value);
    				serie.data.Add(period_final_value);
    			}
    		}
    		
    		series.Add(serie);
    	}
    }
    ...
    
    var legend = new[] { obj_legend };
    var obj4 = new { legend = new[] { obj_legend }, chart, series, xAxis };
    modified_listofstrings.Add(obj4);
    jSearializer.Serialize(modified_listofstrings);

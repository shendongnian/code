	public ApiResult Deserialize(string json)
	{
		ApiResult result = new ApiResult();
		dynamic d = JsonConvert.DeserializeObject(json);
		if (d.propertyA.GetType() == typeof (Newtonsoft.Json.Linq.JObject))
		{
            // propertyA is a single object, construct ApiItem manually
			ApiItem item = new ApiItem();
			item.First = d.propertyA.first;
			item.Second = d.propertyA.second;
            // assign item to result.PropertyA[0]
			result.PropertyA = new ApiItem[1];
			result.PropertyA[0] = item;
		}
		else if (d.propertyA.GetType() == typeof (Newtonsoft.Json.Linq.JArray))
		{
            // propertyA is an array, deserialize json into ApiResult
		    result = JsonConvert.DeserializeObject<ApiResult>(json);
		}
		return result;
	}

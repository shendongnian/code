	static ApiResult Deserialize(string json)
	{
		JObject j = JObject.Parse(json);
		var propA = j["propertyA"];
		switch (propA.Type.ToString())
		{
			case "Object":
				return new ApiResult {
					PropertyA = new[]{propA.ToObject<ApiItem>()},
					SomethingElse = j["somethingElse"].ToObject<string>(),
				};
			case "Array":
				return j.ToObject<ApiResult>();
			default:
				throw new Exception("Invalid json with propertyA of type " + propA.Type.ToString());
		}
	}

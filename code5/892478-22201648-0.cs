    using Newtonsoft.Json; // JsonConvert.SerializeObject
...
	[OperationContract]
	[WebGet(ResponseFormat = WebMessageFormat.Json,
		   UriTemplate = "data?limit={limit}")]
	public System.ServiceModel.Channels.Message LoadData_Limited(int limit) {
		if (limit <= 0) { return null; }
		string query = ...;
		try {
			...
			//Return data from query
			DataTable dt = QueryDatabase(connString, query, parameters);
			string serialized = JsonConvert.SerializeObject(dt);
			return WebOperationContext.Current.CreateTextResponse(serialized);
		} catch {
			return null;
		}
	}

	var ReqObj = new Request() {
		Action = "GetUsers",
		Queries = new List<DynamicQueries> {
			new DynamicQueries {
				Query = new Dictionary<string,string> {
					{ "Query1", "True" },
					{ "Query2", "false" }
				}
			}
		}
	};

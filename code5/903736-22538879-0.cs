	 private static readonly Dictionary<string, Dictionary<string, DirectoryInfo[]>> 
	OrderTypeToFulfillmentDict = new Dictionary<string, Dictionary<string, DirectoryInfo[]>>()
		 {
			 {"Type1", new [] 
				{ 
					ProductsInfo.Type1FulfillmentNoSurfacesLocations, 
					ProductsInfo.Type2FulfillmentSurfacesLocations 
				} 
		}
	}

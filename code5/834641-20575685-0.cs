        public static bool UpdateItem<TItem>(this HttpClient httpClient, TItem item, string uriBase, string actionName) where TItem : class
        {
            var response = await httpClient.PutAsJsonAsync(string.Format(uriBase, actionName), item);
			
            response.EnsureSuccessStatusCode();
            .
            .
            .
            return success;
        }
		

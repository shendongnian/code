            var httpClient = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(_uriBuilder.Query);
            foreach (var id in ids)
            {
                queryString.Add("ids", id.ToString());
            }
            var response = httpClient.DeleteAsync(queryString.ToString());
 

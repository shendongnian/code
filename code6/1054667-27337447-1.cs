            var httpClient = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var id in ids)
            {
                queryString.Add("ids", id.ToString());
            }
            var response = httpClient.DeleteAsync(queryString.ToString());
 

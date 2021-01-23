        /// <summary>
        /// Gets the response Asynchronously.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A parsed response, or throws an exception.</returns>
        public async Task<TResponse> GetResponseAsynchronously(TRequest request)
        {
            var requestUrl = CreateRequestUrl(request);
            HttpClient APIRequest = new HttpClient();
            var response = await APIRequest.GetAsync(requestUrl).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            string downloadedString = await response.Content.ReadAsStringAsync();
            var result = ConvertClientResultString(downloadedString);                      
            
            return result;
        }

	public async Task<string> GetStringAsync(string requestUri, TimeSpan timeout)
	{
		using (var cts = new CancellationTokenSource(timeout))
		{
			HttpResponseMessage response = await _httpClient.GetAsync(requestUri, cts.Token)
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsStringAsync();
		}
	}

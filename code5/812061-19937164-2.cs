    public async Task<string> GetResultAsync(string url)
    {
      await GetInformationAsync(url);
      return result;
    }

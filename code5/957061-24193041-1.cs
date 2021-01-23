    public async Task<string> GetProjectsAsync()
    {
      var json = JsonConvert.SerializeObject(await _repository.AllAsync<Projects>());
      return json;
    }

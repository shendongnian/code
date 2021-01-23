    public string GetProjects()
    {
      var json = JsonConvert.SerializeObject(_repository.All<Projects>());
      return json;
    }

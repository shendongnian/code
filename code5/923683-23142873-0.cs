    public async Task<IEnumerable<Model>> Get([FromUri]IList<string> links)
    {
      IList<Model> list = new List<Model>();
      foreach (var link in links)
     {
         MyRequestAsync request = new MyRequestAsync(link);
         list.Add(await request.GetResult().ConfigureAwait(false));
    }
    return list;

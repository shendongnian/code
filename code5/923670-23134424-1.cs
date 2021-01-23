    public async Task<IEnumerable<Model>> Get([FromUri]IList<string> links)
    {
        IList<Task<Model>> list = new List<Task<Model>>();
        foreach (var link in links)
        {
            MyRequestAsync request = new MyRequestAsync(link);
            list.Add(request.GetResult());
        }
    
        return new List<Model>(await Task.WhenAll(list));
        //Or just
        //return await Task.WhenAll(list);
        //Since we don't need to return a list
    }

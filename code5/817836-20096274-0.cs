    public async Task LoadDataAsync()
    {
      _ctx = new TheContext(the URI);
      _dataSource = new DataServiceCollection<TheEntity>(_ctx);
      var query = _ctx.TheEntity;
      var data = await query.ExecuteAsync();
      _dataSource.Clear(true);
      _dataSource.Load(data);
    }

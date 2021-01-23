    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        var result = await Task.Run(() => _ctx.MyEntities.Where(a => a.Name.Contains("mx")).ToListAsync());
        // Do stuff with your data
        txtInfo.Text = "Loaded Data";
    }

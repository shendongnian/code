    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Task.Factory.StartNew(async () =>
        {
            using (var ctx = new EfDbContext())
            {
                var result = await ctx.MyEntities.Where(a => a.Name.Contains("mx")).ToListAsync();
                this.Invoke(new Action<string>(s => txtInfo.AppendText(s)), result.Count.ToString(CultureInfo.InvariantCulture));
            }
        });
    }

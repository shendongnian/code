    protected override void Seed(Context context)
    {
       context.Database.ExecuteSqlCommand("Command Here");
    }
    base.Seed(context);

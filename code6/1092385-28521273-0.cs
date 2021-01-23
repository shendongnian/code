    private void SeedsQuery(object o)
    {
        StatProperty property = o as StatProperty;
        Expression<Func<QueuedGame, bool>> predicate = x => x.IsSeed;
        using (SteelPoppyContext context = new SteelPoppyContext())
        {
                property.Value = context.QueuedGames.Count(predicate);
        }
    }

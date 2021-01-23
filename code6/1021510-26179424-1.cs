    public IEnumerable<Widget> Widgets
    {
        get
        {
            return dbContext.Widgets.Where(w => w.Owner.Id == User.Id);
        }
    }

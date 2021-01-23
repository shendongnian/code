    private void OnTick(object sender, EventArgs e)
    {
        var now = DateTime.Now;
        var christmasDay = NextChristmas();
        if (now.Date < christmasDay.Date)
        {
            // it's not christmas yet, nothing happens
        }
        if (now.Date == christmasDay.Date)
        {
            // it's christmas, do your thing
            itsChristmas();
        }
    }
    private DateTime NextChristmas()
    {
        var thisYearsChristmas = new DateTime(DateTime.Now.Year, 12, 25);
        if (DateTime.Now.Date <= thisYearsChristmas.Date) return thisYearsChristmas;
        return thisYearsChristmas.AddYears(1);
    }

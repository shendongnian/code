    private void OnTick(object sender, EventArgs e)
    {
        var now = DateTime.Now;
        // normally you would retrieve next christmas from local storage
        var christmasDay = DateTime.Parse("25/12/2013");
        if (now.Date < christmasDay.Date)
        {
            // it's not christmas yet, nothing happens
        }
        if (now.Date == christmasDay.Date)
        {
            // it's christmas, do your thing
            itsChristmas();
        }
        if (now.Date > christmasDay.Date)
        {
            // chrismas has passed, set christmas for next year
            christmasDay = christmasDay.AddYears(1);
            // store christmas to local storage
        }
    }

    protected void lblFriday_PreRender(object sender, EventArgs e)
    {
        Label lblFriday = sender as Label;
        decimal d;
        if(Decimal.TryParse(lblFriday.Text, out d))
        {
             lblFriday.CssClass += d < 0 ? " negative" : d > 0 ? " positive" : String.Empty;
        }
    }

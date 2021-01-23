    bool order, number, warnumber.
    public void OrderTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        order = OrderTxt.Text != string.empty;
		SetRequired();
    }
    public void NumberTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        number = NumberTxt.Text != string.empty;
		SetRequired();
    }
    public void WarNumberTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        warnumber = WarNumberTxt.Text != string.empty;
		SetRequired();
    }
	public void SetRequired()
	{
        NumberTxt.SetValue(Controls.Props.IsRequiredProperty, !(order || number || warnumber));
        OrderTxt.SetValue(Controls.Props.IsRequiredProperty, !(order || number || warnumber));
        WarNumberTxt.SetValue(Controls.Props.IsRequiredProperty, !(order || number || warnumber));
	}
	

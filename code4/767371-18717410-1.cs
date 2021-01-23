    private void Button1_EnabledChanged(object sender, System.EventArgs e)
    {
	Button1.ForeColor = sender.enabled == false ? Color.Blue : Color.Red;
	Button1.BackColor = Color.AliceBlue;
    }

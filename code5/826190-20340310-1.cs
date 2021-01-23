	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		Panel1.Visible = Panel2.Visible = false;
		if (RadioButtonList1.SelectedValue == "P1")
			Panel1.Visible = true;
		else if (RadioButtonList1.SelectedValue == "P2")
			Panel2.Visible = true;
	}

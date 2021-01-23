    private void radioButton7_CheckedChanged(object sender, EventArgs e)
	{
		if (radioButton7.Checked)
		{
			double hpp = 4.20;
			PizzaPrice += hpp;
			txtPizzaPrice.Text = "£ " + PizzaPrice.ToString();
			SummaryBox.Text = radioButton7.Text;
		}
		else
		{
			SummaryBox.Clear();
		}
	}

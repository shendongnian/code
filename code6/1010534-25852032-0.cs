    public void Detail1_Format()
    { DataDynamics.ActiveReports.TextBox tb1;
	String s;
	Double d;
	Decimal d2;
	String ColName;
	s = ((DataDynamics.ActiveReports.TextBox) rpt.Sections["Detail1"].Controls["txtValue1"]).Text;
	ColName = ((DataDynamics.ActiveReports.TextBox) rpt.Sections["Detail1"].Controls["txtColName1"]).Text;
	if((ColName == "Price" || ColName == "Original Face Value" || ColName == "Shares"))
	{
		if(Double.TryParse(s, out d) == true)
		{
			d = Convert.ToDouble(s);
			tb1 = (DataDynamics.ActiveReports.TextBox) rpt.Sections["Detail1"].Controls["txtValue1"];
			d2 = Convert.ToDecimal(s);
			if((BitConverter.GetBytes(decimal.GetBits(d2)[3])[2]) > 2)
			{tb1.Text = d.ToString("#,##0.00########");}
			else 
			{tb1.Text = d.ToString("#,###.00");
			}
			((DataDynamics.ActiveReports.TextBox) rpt.Sections["Detail1"].Controls["txtValue1"]).Text = tb1.Text;}
	}
	else {
		((DataDynamics.ActiveReports.TextBox) rpt.Sections["Detail1"].Controls["txtValue1"]).Text = ((DataDynamics.ActiveReports.TextBox) rpt.Sections["Detail1"].Controls["txtValue1"]).Text;
	}
    }

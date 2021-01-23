	if (row.Cells[4].Value != null)
	{
		if (row.Cells[4].Value.ToString() == "Outbound")
		{
			row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
		}
		else if (row.Cells[4].Value.ToString() == "Inbound")
		{
			row.DefaultCellStyle.BackColor = Color.LightCyan;
		}
		else
		{
			row.DefaultCellStyle.BackColor = Color.White;
		}
	}
	else
	{
		row.DefaultCellStyle.BackColor = Color.White;
	}

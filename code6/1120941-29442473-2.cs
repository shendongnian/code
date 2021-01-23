    	SqlConnection cs2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\\Users\Nikola\documents\visual studio 2010\Projects\Gym Software\Gym Software\Data.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
	sda = new SqlDataAdapter("Select DatumIstice FROM Korisnici", cs2);
	foreach (DataGridViewRow row in dataGridView1.Rows)
	{
	    var now = DateTime.Now;
	    var expirationDate = DateTime.Parse(row.Cells[5].Value.ToString());
	    var sevenDayBefore = expirationDate.AddDays(-7);
	    if (now > sevenDayBefore && now < expirationDate)
	    {
	        row.DefaultCellStyle.BackColor = Color.Yellow;
	    }
	    else if (now > expirationDate)
	    {
	        row.DefaultCellStyle.BackColor = Color.Red;
	    }
	}

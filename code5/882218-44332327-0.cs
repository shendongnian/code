	private iGDropDownList myCombo = new iGDropDownList();
	private void Form1_Load(object sender, EventArgs e)
	{
		myCombo.Items.Add(1);
		myCombo.Items.Add(2);
		myCombo.Items.Add(3);
		myCombo.Items.Add(4);
		iGrid1.DefaultCol.CellStyle.DropDownControl = myCombo;
		iGrid1.Cols.Count = 50;
		iGrid1.Rows.Count = 50;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		var i = comboBox1.SelectedIndex;
		var p = (new [] { p1, p2 })[i]; // Or `var p = i == 0 ? p1 : p2;`
		p.Show();
		comboBox2.Items.Add(i + 1);
		p.setStatus("A");
	}

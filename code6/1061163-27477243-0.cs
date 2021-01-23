	private void button1_Click(object sender, EventArgs e)
	{
		var SearchIn = textBox3.Text.ToUpper();
		
		var query =
			from c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
			let count = SearchIn.Count(x => x == c)
			select String.Format("{0}: {1}", c, count);
		
		textBox4.Text = String.Join(Environment.NewLine, query);        
	}

	private void button1_Click(object sender, EventArgs e)
	{
		var SearchIn = textBox3.Text.ToUpper();
		var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
	
	    var query =
	        from c in alphabet
	        let matches = SearchIn.Where((x, n) => x == c).ToList()
	        select String.Format("{0}: {1}", c, matches.Count());
		
		textBox4.Text = String.Join(Environment.NewLine, query);        
	}

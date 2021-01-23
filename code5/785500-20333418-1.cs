    private void textBox1_TextChanged(object sender, EventArgs e)
	{
		//Remove previous formatting, or the decimal check will fail including leading zeros
		string value = textBox1.Text.Replace(",", "")
            .Replace("$", "").Replace(".", "").TrimStart('0');
		decimal ul;
		//Check we are indeed handling a number
		if (decimal.TryParse(value, out ul))
		{
			ul /= 100;
			//Unsub the event so we don't enter a loop
			textBox1.TextChanged -= textBox1_TextChanged;
			//Format the text as currency
			textBox1.Text = string.Format(CultureInfo.CreateSpecificCulture("en-US"), "{0:C2}", ul);
			textBox1.TextChanged += textBox1_TextChanged;
			textBox1.Select(textBox1.Text.Length, 0);
		}
		bool goodToGo = TextisValid(textBox1.Text);
		enterButton.Enabled = goodToGo;
		if (!goodToGo)
		{
			textBox1.Text = "$0.00";
			textBox1.Select(textBox1.Text.Length, 0);
		}
	}
    private bool TextisValid(string text)
    {
        Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
        return money.IsMatch(text);
    }

    private void button1_Click(object sender, EventArgs e)
    {
    	var textInEachLine = richTextBox1.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    	string whereClause = string.Join("', '", textInEachLine).ToString();
    	MessageBox.Show(" IN ( '" + whereClause + "')");
    }

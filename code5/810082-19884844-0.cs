    private void userTextBox_TextChanged(object sender, EventArgs e)
    {
    	string userInput = userTextBox.Text;
    	userInput = userInput.Trim();
    	string[] wordCount = userInput.Split(null);
    	
    	int charCount = 0;
    	foreach (var word in wordCount)
    		charCount += word.Length;
    	
    	wordCountOutput.Text = wordCount.Length.ToString();
    	charCountOutput.Text = charCount.ToString();
    }

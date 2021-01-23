    String[] lines = 
    		StringFromRichTextBox(rtb).Split(new[]{Environment.NewLine}
    										  , StringSplitOptions.RemoveEmptyEntries);
    foreach (var line in lines)
    {
    	MessageBox.Show(line);
    }

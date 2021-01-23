    private btnFind_Click(Object sender, EventArgs e)
    {
        if(CountStringOccurrences(txtNotePad.Text, txtToFind.Text) > 0)
        {
            MessageBox.Show("Found 1 or multiple matches");
        }
        else
        {
            MessageBox.Show("Didn't found match...");
        }
    }
    //CountStringOccurrences, takes full text + string to match with
    //Returns the amount of matches found in full text
    public static int CountStringOccurrences(string text, string pattern)
    {
    	// Loop through all instances of the string 'text'.
    	int count = 0;
    	int i = 0;
    	while ((i = text.IndexOf(pattern, i)) != -1)
    	{
    	    i += pattern.Length;
    	    count++;
    	}
    	return count;
    }

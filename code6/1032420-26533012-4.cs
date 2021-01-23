    int indexOfSearchText = 0;
    int start = 0;
    int cursorPos = -1;
    private void btnListSearch_Click(object sender, EventArgs e)
    {
        cursorPos = rtb.SelectionStart;
        clearHighlights();
        int startindex = 0;
        start = 0;
        indexOfSearchText = 0;
        if (txtSearch.Text.Length > 0)
            startindex = FindMyText(txtSearch.Text.Trim(), start, rtb.Text.Length);
            while (startindex>=0) 
            {
                // If string was found in the RichTextBox, highlight it
                if (startindex >= 0)
                {
                    // Set the highlight color as red
                    // Find the end index. End Index = number of characters in textbox
                    int endindex =  txtSearch.Text.Length;
                    // Highlight the search string
                    rtb.Focus();
                    rtb.Select(startindex, endindex);
                    rtb.SelectionColor = Color.Red;
                    // mark the start position after the position of 
                    // last search string
                    start = startindex + endindex;
                }
                startindex = FindMyText(txtSearch.Text.Trim(), start, rtb.Text.Length);
            }
        // keep the highlighting but clear the selection
        rtb.Select(cursorPos , 0);
    }
    public int FindMyText(string txtToSearch, int searchStart, int searchEnd)
    {
        // Unselect the previously searched string ??? NO!!!
        // Set the return value to -1 by default.
        int retVal = -1;
        // A valid starting index should be specified.
        // if indexOfSearchText = -1, the end of search
        if (searchStart >= 0 && indexOfSearchText >= 0)
        {
            // A valid ending index 
            if (searchEnd > searchStart || searchEnd == -1)
            {
                // Find the position of search string in RichTextBox
                indexOfSearchText = rtb.Find(txtToSearch, searchStart, 
                                             searchEnd, RichTextBoxFinds.None);
                // Determine whether the text was found in richTextBox1.
                if (indexOfSearchText != -1)
                {
                    // Return the index to the specified search text.
                    retVal = indexOfSearchText;
                }
            }
        }
        return retVal;
    }
    void clearHighlights()
    {
        rtb.Select(0, rtb.TextLength);       // select all
        rtb.SelectionColor = rtb.ForeColor;  // default text color
        rtb.Select(rtb.TextLength, 0);       // select nothing
    }

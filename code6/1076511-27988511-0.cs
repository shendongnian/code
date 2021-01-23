    private void fixContent()
    {
        String text = txtAutoComplete.Text;
        List<String> matchedResults = new List<String>();
        //Iterate through textbox autocompletecustomsource
        foreach (String ACLine in txtAutoComplete.AutoCompleteCustomSource)
        {
            //Check ACLine length is longer than text length or substring will raise exception
            if (ACLine.Length >= text.Length)
            {
                //If the part of the ACLine with the same length as text is the same as text, it's a possible match
                if (ACLine.Substring(0, text.Length).ToLower() == text.ToLower())
                    matchedResults.Add(ACLine);
            }
        }
            
        //Sort results and set text to first result
        matchedResults.Sort();
        txtAutoComplete.Text = matchedResults[0] 
    }

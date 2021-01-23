    var regex = new Regex("(" + SearchTextBox.Text + ")", RegexOptions.IgnoreCase);
        
    if (SearchTextBox.Text.Length == 0)
    {
        string str = Content.Text;
        Content.Inlines.Clear();
        Content.Inlines.Add(str);
    }
    else
    {
        //get all the words from the 'content'
        string[] substrings = regex.Split(Content.Text);
        Content.Inlines.Clear();
       
        foreach (var item in substrings)
        {
            //if a word from the content matches the search-term
            if (regex.Match(item).Success)
            {
                //create a 'Run' and add it to the TextBlock
                Run run = new Run(item);
                run.Foreground = Brushes.Red;
                Content.Inlines.Add(run);
            }
            else //if no match, just add the text again
                Content.Inlines.Add(item);
        }
    }

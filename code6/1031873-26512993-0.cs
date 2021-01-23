    private void OnTextChanged(object sender, EventArgs e)
    {
        TextBox myTextArea = (sender as TextBox);
        if (myTextArea.Text.Length > 3)
        {
            char period = myTextArea.Text.ElementAtOrDefault(myTextArea.Text.Length - 3);
            char space = myTextArea.Text.ElementAtOrDefault(myTextArea.Text.Length - 2);
            char newestCharAdded = myTextArea.Text.Last();
            if(period == '.' && space == ' ' && char.IsLetter(newestCharAdded))
            {
                CapitalizeFunction(myTextArea, newestCharAdded);
            }
        }
        else if (myTextArea.Text.Length == 1)
        {
            char newestCharAdded = myTextArea.Text.Last();
            if(char.IsLetter(newestCharAdded))
            {
                CapitalizeFunction(myTextArea, newestCharAdded);                    
            }
        }
    }

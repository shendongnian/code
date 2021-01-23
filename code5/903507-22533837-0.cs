    //Initially in the form
    string lastFetchedId = string.Empty;
    //KeyDown code
    //Remove AcceptButton, if string is being edited etc. Anything other than enter
    if (e.KeyCode != Keys.Enter) this.AcceptButton = null;
    else
    {
        //If something changed
        if (lastFetchedId != textBox.Text)
        {
           //Have Fetch return a true or false, after filling data in the textboxes
           if (fetchdetails(textBox.Text))
           {
             lastFetchedId = textBox.Text;
             this.AcceptButton = btnSave;
           }
        }
    }

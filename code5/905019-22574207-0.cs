    var textBoxes = new [] {
        new { txb = txtUserName, name = "txtUserName" },
        new { txb = txtPassw, name = "txtPassw" },
        new { txb = txtDatabase , name = "txtDatabase " }
    };
    
    var empty = textBoxes.Where(x => String.IsWhitespaceOrEmpty(x.txb.Text)).ToList();
    
    if(empty.Any() && empty.Count != textboxes.Length)
    {
        MessageBox.Show("Please enter " + String.Join(" and ", empty.Select(x => x.name)));
    }

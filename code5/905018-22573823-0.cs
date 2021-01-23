    var textBoxes = new [] {
        new { txb = txtUserName, name = "txtUserName" },
        new { txb = txtPassw, name = "txtPassw" },
        new { txb = txtDatabase , name = "txtDatabase " }
    };
    
    var empty = textBoxes.Where(x => x.txb.Text == "").ToList();
    
    if(empty.Any())
    {
        MessageBox.Show("Please enter " + String.Join(" and ", empty.Select(x => x.name)));
    }

    DateTime musDate;
    if(!DateTime.TryParse(txtMusDate.Text, out musDate))
    {
        MessageBox.Show("Please enter a valid mus-date.");
        return;
    }
    // here you can use musDate

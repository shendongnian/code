    var clientName = nameBox.Text.Trim(); // after validating that it's not null or empty
    if (!records.Any(c => string.Equals(c.Name, clientName, StringComparison.InvariantCultureIgnoreCase)))
    {
         records.Add(new Client { Name = clientName } );
    }
    else
    {
         MessageBox.Show("Member already exists");
    }

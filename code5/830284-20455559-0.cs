    if(listOfConnections.Count == 0) listOfConnections.Add(new Connection());
    else if(listOfConnections.Count == 1) MessageBox.Show("Whatever");
    //or better yet
    if (listOfConnections.Any())
    { 
        MessageBox.Show("Whatever");
    }
    else
    {
        listOfConnections.Add(new Connection());
    }

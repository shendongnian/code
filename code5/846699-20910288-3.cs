    try
    {
        var items = Repo.getData();
        ...
    }
    catch (ConnectionFailedException)
    {
        MessageBox.Show("There was a problem accessing the database, please try again.");
    }

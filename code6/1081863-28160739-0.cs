    if (result.Read())
    {
        model = new Model.Customer()
        {
            Username = result.GetString(0),
            Password = result.GetString(1)
        };
    }

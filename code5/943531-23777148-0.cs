    private void Update()
    {
        if (!changed)
            return;
        // If field inside your class has been changed connect to the database and use stored 
        // procedure to save/update person. Pass class values into your stored procedure. If
        // ID is not set add new person, else update the person with existing ID
    }
    private void Delete()
    {
        // Delete person by ID
    }

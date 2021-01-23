    SqlConnection connection;
    SqlCommand command;   <-- make command instance var
    void SomeMethod()
    {
        // Assume connection is an open SqlConnection.
        // Create a new SqlCommand object.
        if ( command == null )
        {
           command = new SqlCommand("SELECT * FROM dbo.ArchivioErogazioni", connection);
          // Create a dependency and associate it with the SqlCommand.
        }
        else{
           command.Notification = null;  // this cancels any previous notifcation object
        }
        SqlDependency dependency = new SqlDependency(command);
        // Maintain the refence in a class member.
        // Subscribe to the SqlDependency event.
        dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);
        // Execute the command.
        command.ExecuteReader();
    }

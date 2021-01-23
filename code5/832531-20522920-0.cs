    //open a SQL Server database connection using the client credentials 
    using (var impcontext = ServiceSecurityContext.Current.WindowsIdentity.Impersonate())
    {
        var dbConnection = new System.Data.SqlClient.SqlConnection("Data Source=myServer; Integrated Security=SSPI");
        dbConnection.Open();
        impcontext.Undo();
    }

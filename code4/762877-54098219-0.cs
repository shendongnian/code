    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    ....
    string query = @" //sql multi-command text here"
    using (SqlConnection thisconn = new SqlConnection(connectionString)) {
        Server db = new Server(new ServerConnection(thisconn));
        db.ConnectionContext.ExecuteNonQuery(query);
    }

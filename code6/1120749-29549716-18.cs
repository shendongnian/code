    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.IO;
    using System.Data.SqlClient;
    [SetUp]
    public void TestSetUp()
    {
        string sqlConnectionString = @"server=test.database.com;uid=your_db_username;pwd=your_db_password;database=Your_Database;";
        string script = File.ReadAllText(@"~/create_db_snapshot.sql");
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        Server server = new Server(new ServerConnection(conn));
        server.ConnectionContext.ExecuteNonQuery(script);
    }
    [TearDown]
    public void TearDown()
    {
        string sqlConnectionString = @"server=test.database.com;uid=your_db_username;pwd=your_db_password;database=Your_Database;";
        string script = File.ReadAllText(@"~/restore_db_from_snapshot.sql");
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        Server server = new Server(new ServerConnection(conn));
        server.ConnectionContext.ExecuteNonQuery(script);
    }
Snapshot documentation: https://msdn.microsoft.com/en-us/library/ms175158.aspx
Code credit for executing .sql file: https://stackoverflow.com/a/1728859/3038677
###You might also need to run this script prior to executing restore_db_from_snapshot.sql...

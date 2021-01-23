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
    	
        string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";
        string script = File.ReadAllText(@"~/create_db_snapshot.sql");
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        Server server = new Server(new ServerConnection(conn));
        server.ConnectionContext.ExecuteNonQuery(script);
        /* execute db-cola here if you need to update your database prior to running tests 
        ExecDbCola();
        */
    }
    [TearDown]
    public void TearDown()
    {
    	
        string sqlConnectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ccwebgrity;Data Source=SURAJIT\SQLEXPRESS";
        string script = File.ReadAllText(@"~/restore_from_db_snapshot.sql");
        SqlConnection conn = new SqlConnection(sqlConnectionString);
        Server server = new Server(new ServerConnection(conn));
        server.ConnectionContext.ExecuteNonQuery(script);
    }
    public void ExecDbCola()
    {
    	// Prepare the process to run
    	ProcessStartInfo start = new ProcessStartInfo();
    	// Enter in the command line arguments
    	start.Arguments = arguments; 
    	// Enter the executable to run, including the complete path
    	start.FileName = ~/full/path/to/exe/db-cola.exe;
    	// Do you want to show a console window?
    	start.WindowStyle = ProcessWindowStyle.Hidden;
    	start.CreateNoWindow = true;
    	int exitCode;
    	// Run the external process & wait for it to finish
    	using (Process proc = Process.Start(start))
    	{
    	     proc.WaitForExit();
    	     // Retrieve the app's exit code
    	     exitCode = proc.ExitCode;
    	}
    }

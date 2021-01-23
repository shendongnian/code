    // Utilize the using directive on any disposable objects so you aren't left with garbage.
    using (SqlConnection cn = new SqlConnection(Settings.Server.ConnectionString))
    using (SqlCommand cmd = new SqlCommand("spMyStoredProcedure", cn))
    {
    	cmd.CommandType = CommandType.StoredProcedure;
        // define your parameter here, just personal preference, but makes debugging easier in my opinion.
    	string slug = Page.Request.QueryString["_slug"];
        // Use the newer .AddWithValue command.
    	cmd.Parameters.AddWithValue("@strslug", slug);
    	JJ.Diagnostics.Tracer.Trace(cmd);
    	
        // Try to open your connection only when it is required to be open.
    	cn.Open();
    	try
    	{
            // Data adapter will automatically fill your returned data table.
    		using (SqlDataAdapter da = new SqlDataAdapter(cmd, cn)
    		{
    			DataTable dt = new DataTable("TableName");
    			da.Fill(dt);
    			return dt;
    		}
    	}
    	catch (SqlException exSql)
    	{
    		// Make an event log entry of the exception
    		EventLogController.LogException(exSql);
    		throw;
    	}
    	catch (Exception ex)
    	{
    		// Make an event log entry of the exception
    		EventLogController.LogException(ex);
    		throw;
    	}
    }

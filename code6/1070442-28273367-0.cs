    void OnDependencyChange(object sender, SqlNotificationEventArgs e)
    {
        // Resubscription
        using (SqlCommand command=new SqlCommand("SELECT * FROM dbo.insight"
                , connectionString))
        {
            command.Notification = null;
            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += new OnChangeEventHandler(OnDependencyChange);
            command.ExecuteReader();
        }
        Dictionary<string, string> data = new Dictionary<string, string> { };
        data.Add("Id","34");
        data.Add("DeviceId", "163-117")
        data.Add("DeviceUserName", "Someone");
        var result = new[] { data };
        Clients.All.addData(result);
    }

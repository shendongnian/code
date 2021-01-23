     [HubMethodName("removeNotifications")]
        public string RemoveNotifications(int newMessages)
        {
            if(newMessages < 0)
            {
                return context.Clients.All.RecieveNotification(0);
            }
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("UPDATE Messages SET NewMessageCount=@NewMessageCount", connection))
                    {
                        command.Parameters.AddWithValue("@NewMessageCount", newMessages);
                        command.Notification = null;
                        DataTable dt = new DataTable();
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
    
                        connection.Open();
                        var reader = command.ExecuteReader();
                    }
                    connection.Close();
                }
                    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                    return context.Clients.All.RecieveNotification(newMessages);
        }

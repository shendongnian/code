            string connectionString = "Data Source=XXXX;Initial Catalog=XXXX;Integrated Security=True";
            string sqlQuery = "Select * from notifications";
            List<Notification> notifications = new List<Notification>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand comm = new SqlCommand(sqlQuery, conn))
                {
                    comm.CommandType = CommandType.Text;
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Notification notification = new Notification();
                            notification.FriendName = reader["friend_name"].ToString();
                            notification.Notification = reader["notifications"].ToString();
                            notification.Date = reader["notification_time"].ToString();
                            notifications.Add(notification);
                        }
                    }
                }
            }
            DropDownItems.DataSource = notifications;
            DropDownItems.DataBind();

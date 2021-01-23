    private async Task RegisterSqlDependency()
        {
            if (_dependency != null)
                _dependency.OnChange -= this.OnChange;
            String query = "select MyCol from dbo.MyTable WHERE myKey = '" + _dependecyKey + "'";
            
            using (SqlConnection connexion = new SqlConnection("ConnexionString"))
            {
                using (SqlCommand command = new SqlCommand(query, connexion))
                {
                    _dependency = new SqlDependency(command, null, 0);
                    _dependency.OnChange += this.OnChange;
                    await connexion.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                           .... GetData ....
                        }
                    }
                }
            }
        }
    private void OnChange(object sender, SqlNotificationEventArgs e)
        {
          .... Data has changed on table ....
          call RegisterSqlDependency() again
        }

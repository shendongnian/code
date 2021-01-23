    int id = 0;
    string query = @"SELECT [TableName] WHERE [Email] = @Email;";
    
    if(Page.IsPostBack)
         using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"Db].ConnectionString))
              using(SqlCommand command = new SqlCommand(query, connection))
              {
                   connection.Open();
                   command.Parameters.AddWithValue("@Email", txtEmailField.Text);
                   id = (Int32)command.ExecuteScalar();
                   if(id == 1)
                     Page.RegisterClientStartupScript(this.GetType(), @"Error", @"alert('Duplicate Email');");
              }

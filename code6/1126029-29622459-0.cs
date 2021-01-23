    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
    connection.Open();           
    
    string phone = Label1.Text;
    Label1.Visible = true;
    
    SqlCommand com1 = new SqlCommand("select * from DB where Phone=@phone", connection);
    com1.Parameters.AddWithValue("@phone", Label.Text);
    SqlDataReader reader = com1.ExecuteReader();
    if (reader.HasRows()) 
    {
       while (reader.Read())
       {
          phone = reader["ColumnName"].toString();
       }
    }   
    string AccountSid = "MyCode";
    string AuthToken = "MYCODE";
    
    var message = new TwilioRestClient(AccountSid, AuthToken);
    var sms = message.SendMessage("MyNumber", phone, "Message Sent.", "");
    Console.WriteLine(sms.Sid);

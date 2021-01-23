     public class EmailModel
     {
    	 public string ToAddress {get; set;}
    	 public string Username {get; set;}
     }
    var myCommand = new SqlCommand("SELECT aspnet_Membership.Email, aspnet_Users.UserName, User_Profile.FirstName FROM aspnet_Membership INNER JOIN aspnet_Users ON aspnet_Membership.UserId = aspnet_Users.UserId INNER JOIN User_Profile ON aspnet_Users.UserId = User_Profile.UserId WHERE (aspnet_Membership.UserId = @UserId)");
    myCommand.Parameters.AddWithValue("@UserId", newUserId);
    var emails = new List<EmailModel>();
    using (var myConnection = new SqlConnection(connectionString))
    {
    	myCommand.Conection = myConnection;
        myConnection.Open();           
        reader = myCommand.ExecuteReader();    
        while (reader.Read())
         {
    		 emails.Add(new EmailModel(){
    			 ToAddress = reader["email"].ToString(),
    			 Username = reader["UserName"].ToString()
    		 });		 
         }
    }
    
    foreach (var email in emails)
     {
    
    	 //send new confirmation email
    	 SmtpClient smtpclient = new SmtpClient();
    	 MailMessage mail = new MailMessage();
    	 MailAddress fromaddress = new MailAddress("-------------", "--------");
    	 smtpclient.Host = "---------";
    	 smtpclient.Port = 25;
    	 mail.From = fromaddress;
    	 mail.To.Add(email.ToAddress);
    	 mail.Subject = ("Welcome to -------"");
    	 mail.IsBodyHtml = true;
    	 mail.Body = "Hi "+email.Username;
    	 smtpclient.EnableSsl = false;
    	 smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
         string smtp_username="";
         string smtp_password="";//better not put this in code, pull it from .config file
    	 smtpclient.Credentials = new System.Net.NetworkCredential(smtp_username, smtp_password);
    	 smtpclient.Send(mail);
     }

    namespace ConsoleApplication3
    {
        using System;
        using System.Collections.Generic;
        using System.Data.OleDb;
        using System.Linq;
        using System.Net.Mail;
        
        public class Program
        {
            public static void Main()
            {
                try
                {
                    List<string> emails = new List<string>();
    
                    int i = 0, email = 0;
                    connection.Open(); //connection to the database.
                    OleDbCommand cmd_Email = new OleDbCommand("Select Email from Email_Table", connection);
                    OleDbDataReader read_Email = cmd_Email.ExecuteReader();
                    if (read_Email.HasRows)
            {
                    while (read_Email.Read())
                    {
                        email = read_Email.GetString(0).FirstOrDefault();
                        emails.Add(email);
                    }
                    read_Email.Close();
                    connection.Close(); //Close connection
                    MailMessage message = new MailMessage() { 
                        Subject = label2.Text + "   station  " + label1.Text, 
                       From = new MailAddress("amrghonem20@gmail.com"),
                        Body = "Test"; 
                };
    
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    emails.ForEach(to =>
                    {
                        message.To.Clear();
                        message.To.Add(to);
                        smtp.Send(message);
                    });
                }
    }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }

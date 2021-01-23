    email = new MailMessage("email@abc.com", ConfigurationManager.AppSettings["Email_To"]);
    email.Subject = "Invalid Courses ";
    email.CC.Add(ConfigurationManager.AppSettings["FYIEmail_CC_Dataload"]);
    
    email.Body = "Test message:";
    foreach(Datarow dr in DsResult.Rows)
    {
    body.Append(please ignore." + objBEAdmin.DsResult.Tables[0].Rows[0]["CourseId"].ToString());
    }
    
    body.Append(@"<tr><td>Hi,<br/><br/> Please find the missing courses </p></td></tr>");
    body.Append("</table>");
    SmtpClient client = new SmtpClient("pod51041.outlook.com", 587);
    client.UseDefaultCredentials = false;
    client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.EnableSsl = true;
    client.Send(email);

            BAdmin objBAdmin = new BAdmin();
            BEAdmin objBEAdmin = new BEAdmin();
            BAdmin objSpAdmin = new BAdmin();
            objSpAdmin.BGetInvalidCourses(objBEAdmin);
         string invalid = objBEAdmin.DsResult.Tables[0].Rows[0]["CourseId"].ToString();
            MailMessage email = new MailMessage();
            StringBuilder body = new StringBuilder();
            
             email = new MailMessage("abc@abc.com", ConfigurationManager.AppSettings["FYIEmail_To_Dataload"]);
            email.Subject = "Invalid Courses ";
            email.CC.Add(ConfigurationManager.AppSettings["FYIEmail_CC_Dataload"]);
            foreach (System.Data.DataRow dr in objBEAdmin.DsResult.Tables[0].Rows)
            {
                body.Append("please ignore." + dr["CourseId"].ToString());
            }
            body.Append(@"<tr><td>Hi,<br/><br/> Please find the missing courses </p></td></tr>");
            body.Append("</table>");
            email.Body = body.ToString();
            email.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("pod51041.outlook.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(email);

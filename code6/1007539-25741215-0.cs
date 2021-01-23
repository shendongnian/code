     try
            {
                string admin_email = "youremail"
                string admin_emailpwd = "your pwd"
                MailMessage mail = new MailMessage();
                mail.To.Add(SendTo);
                mail.From = new MailAddress(admin_email);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "SMTP.gmail.com";
              //  smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(admin_email, admin_emailpwd);
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch
            {
                return false;
            }
            return true;
        }

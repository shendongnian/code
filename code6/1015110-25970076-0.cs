                    var mailItem= new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp server addess");
    
                    mailItem.From = new MailAddress("your_email_address@xyz.com");
                    mailItem.To.Add("it-department@???.co.uk");
                
         
                        mailItem.Subject = string.Format("You have a new task from {0}", comboBox3.Text);
                        mailItem.To = "";
                        mailItem.Body =string.Format("<html><body><p>Dear IT Dept.</p> <p>You have         received a new task to complete from {0} Please check the attached file and     fit the task in to your schedule.</p><p> Once completed please contact the provided contactee for comfirmation the task is completed to their expectations.</p>",textBox2.txt);
                         
                        attachment = new System.Net.Mail.Attachment(@"\\??-filesvr\shares\Shared\+++++Web Projects+++++\????\IssueReport.txt");
                        mailItem.Attachments.Add(@"\\??-filesvr\shares\Shared\+++++Web Projects+++++\??\IssueReport.txt");
                       
                        mailItem.IsBodyHtml = true;
                    
                    // Optional Items based on your smtp server.
                    /* SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                    SmtpServer.EnableSsl = true;*/
    
                    SmtpServer.Send(mailItem);
                    MessageBox.Show("mail Send");

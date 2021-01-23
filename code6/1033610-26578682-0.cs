            [HttpPost]
            public ActionResult Contact(ContactModels c)
            {
                string resultMsg = "There was an error submitting your message. Please try again later.";
                if (!ModelState.IsValid)
                {
                    return Content(resultMsg);
                }
                if (ModelState.IsValid)
                {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("SendersEmail@gmail.com", "ThePassword");
                    
                    string body = string.Format(
                        "First Name: {0}\nLast Name: {1}\nEmail: {2}\nComment: {3}",
                        c.FirstName,
                        c.LastName,
                        c.Email,
                        c.Comment
                    ); \\In this block I added a new line \n to appear better when I receive the email.
                    var message = new MailMessage();
                    message.To.Add("RecipientEmail@gmail.com");
                    message.From = new MailAddress(c.Email, c.Name);
                    message.Subject = String.Format("Contact Request From: {0} ", c.Name);
                    message.Body = body;
                    message.IsBodyHtml = false;
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception)
                    {
                        return View("Error");
                    }
                }                
            }
            return View("Success");

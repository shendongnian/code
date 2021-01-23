    if (ModelState.IsValid)
        {
            var v = (from e in db.todaySalesReport()
                    select e).SingleOrDefault();
            var ctx = new UsersContext();
            string from = "";
            foreach (var i in ctx.UserProfiles.ToList())
            {
                address = i.Email;
                //MailAddress addr = new MailAddress();
                using (MailMessage mail = new MailMessage(from, address))
                {
                        mail.To.Add(i.Email);
                        mail.Subject = "Total Sales Report for today";
                        mail.Body = "Total sales" + v.qty.ToString() + "Peices.";
                        mail.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential networkCredential = new NetworkCredential(from, "");
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = networkCredential;
                        smtp.Port = 587;
                        smtp.Send(mail);
                        ViewBag.Message = "Sent";
                 }
           }
         return View("Index", address);
       }
    

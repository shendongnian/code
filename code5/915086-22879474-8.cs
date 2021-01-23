    [HttpPost]
        public ActionResult Index(EnquiryForm enquiryForm)
        {
          if(ModelState.IsValid)
          {
           
            StringBuilder message = new StringBuilder();
            message.Append("Name: " + enquiryForm.FirstName + " " + enquiryForm.LastName + "\n");
            message.Append("Email Address: " + enquiryForm.EmailAddress + "\n");
            message.Append("Country: " + enquiryForm.Country + "\n");
            message.Append("Party Size: " + enquiryForm.PartySize + "\n");
            message.Append("Arrival Date: " + enquiryForm.ArrivalDate + "/" + enquiryForm.ArrivalMonth + "/" + enquiryForm.ArrivalYear + "\n");
            message.Append("Departure Date: " + enquiryForm.DepartureDate + "/" + enquiryForm.DepartureMonth + "/" + enquiryForm.DepartureYear + "\n");
            message.Append("Questions: " + enquiryForm.Questions);
            
           MailMessage mail = new MailMessage();
           SmtpClient smtpServer = new SmtpClient(ConfigurationManager.AppSettings["SendMailSmtp"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["SendMailFrom"]);
            mail.To.Add(ConfigurationManager.AppSettings["SendMailTo"]);
            mail.Subject = "The Pines Enquiry";
            mail.ReplyToList.Add(enquiryForm.EmailAddress);
            mail.Body = message.ToString();
            smtpServer.Send(mail);
        }
        return View(enquiryForm);
          
        }

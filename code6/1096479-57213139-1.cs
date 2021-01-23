MandrillApi api = new MandrillApi("1xxxx yyyy zzzz");
            Mandrill.Models.EmailMessage email = new Mandrill.Models.EmailMessage();
            email.FromEmail = "certificate@riskhippie.com";
            email.Subject = "Mandrill API Template Replace";
            email.RawMessage = "Hello Pradip Patel";
            email.MergeLanguage = "handlebars";
            
            email.AddGlobalVariable("vendor_name", "FI Custom");
            //your template name
            string TemplateName = "1-Owner to Vendor 1st Req.";
            
            email.To = new List<Mandrill.Models.EmailAddress>()
                {
                  new Mandrill.Models.EmailAddress("pradippatel1411@gmail.com")
                };
                                    
            Mandrill.Requests.Messages.SendMessageTemplateRequest objTemp = 
                new Mandrill.Requests.Messages.SendMessageTemplateRequest(email, TemplateName);
            var results = await api.SendMessageTemplate(objTemp);

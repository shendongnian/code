      var message = Populate(m =>
      {
           m.Subject = subject;
           m.ViewName = viewName;
           m.To.Add(model.CustomerEmail);
           m.From = new System.Net.Mail.MailAddress(model.FromEmail);
       });
       // get the BODY so we can process it
       var body = EmailBody(message.ViewName);
       var processedBody = PreMailer.Net.PreMailer.MoveCssInline(body, true).Html;
       // start again with alternate view
       message.AlternateViews.Clear();
       // add BODY as alternate view 
       var htmlView = AlternateView.CreateAlternateViewFromString(processedBody, new ContentType("text/html"));
       message.AlternateViews.Add(htmlView);
            
       // add linked resources to the HTML view
       PopulateLinkedResources(htmlView, message.LinkedResources);

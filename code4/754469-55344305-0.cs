    var pictures = new[]
    {
        new { id = Guid.NewGuid(), type = "image/jpeg", tag = "justme", path = @"C:\Pictures\JustMe.jpg" },
        new { id = Guid.NewGuid(), type = "image/jpeg", tag = "justme-bw", path = @"C:\Pictures\JustMe-BW.jpg" }
    }.ToList();
    
    var content = $@"
    <style type=""text/css"">
        body {{ font-family: Arial; font-size: 10pt; }}
    </style>
    <body>
    <h4>{DateTime.Now:dddd, MMMM d, yyyy h:mm:ss tt}</h4>
    <p>Some pictures</p>
    <div>
        <p>Color Picture</p>
        <img src=cid:{{justme}} />
    </div>
    <div>
        <p>Black and White Picture</p>
        <img src=cid:{{justme-bw}} />
    </div>
    <div>
        <p>Color Picture repeated</p>
        <img src=cid:{{justme}} />
    </div>
    </body>
    ";
    
    // Update content with picture guid
    pictures.ForEach(p => content = content.Replace($"{{{p.tag}}}", $"{p.id}"));
    // Create Alternate View
    var view = AlternateView.CreateAlternateViewFromString(content, Encoding.UTF8, MediaTypeNames.Text.Html);
    // Add the resources
    pictures.ForEach(p => view.LinkedResources.Add(new LinkedResource(p.path, p.type) { ContentId = p.id.ToString() }));
    
    using (var client = new SmtpClient()) // Set properties as needed or use config file
    using (MailMessage message = new MailMessage()
    {
        IsBodyHtml = true,
        BodyEncoding = Encoding.UTF8,
        Subject = "Picture Email",
        SubjectEncoding = Encoding.UTF8,
    })
    {
        message.AlternateViews.Add(view);
        message.From = new MailAddress("me@me.com");
        message.To.Add(new MailAddress("you@you.com"));
        client.Send(message);
    }

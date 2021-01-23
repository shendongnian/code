    protected override void OnMailSending(MailSendingContext context)
    {
        for (var i = 0; i < context.Mail.AlternateViews.Count; i++)
        {
            var av = context.Mail.AlternateViews[i];
            if (av.ContentType.MediaType == MediaTypeNames.Text.Html)
            {
                av.ContentStream.Position = 0;
                var content = new StreamReader(av.ContentStream).ReadToEnd();
                content = content.Replace("F?sica", "FÃ­sica");
                context.Mail.AlternateViews[i] = AlternateView.CreateAlternateViewFromString(content, av.ContentType);
            }
        }            
        base.OnMailSending(context);
    }

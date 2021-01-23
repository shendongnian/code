	protected override void OnMailSending(MailSendingContext context)
	{
		if (context.Mail.IsBodyHtml)
		{
			var inlineResult = PreMailer.Net.PreMailer.MoveCssInline(context.Mail.Body);
			context.Mail.Body = inlineResult.Html;
		}
		for (var i = 0; i < context.Mail.AlternateViews.Count; i++)
		{
			var alternateView = context.Mail.AlternateViews[i];
			if (alternateView.ContentType.MediaType != AngleSharp.Network.MimeTypeNames.Html) continue;
			using (alternateView) // make sure it is disposed
			{
				string content;
				using (var reader = new StreamReader(alternateView.ContentStream))
				{
					content = reader.ReadToEnd();
				}
				var inlineResult = PreMailer.Net.PreMailer.MoveCssInline(content);
				context.Mail.AlternateViews[i] = AlternateView.CreateAlternateViewFromString(inlineResult.Html, alternateView.ContentType);
			}
		}
		base.OnMailSending(context);
	}

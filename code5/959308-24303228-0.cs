    MailMessage msg = new MailMessage();
    msg.From = new MailAddress("gonzo@work");
    msg.To.Add("gonzo@home");
    
    System.Net.Mime.ContentType mimeType = new System.Net.Mime.ContentType("text/calendar; method=REQUEST");
    AlternateView icalView = AlternateView.CreateAlternateViewFromString(icalendarString, mimeType);
    icalView.TransferEncoding = TransferEncoding.SevenBit;
    msg.AlternateViews.Add(icalView);
    client.Send(msg);

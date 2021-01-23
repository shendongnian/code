        ContentType mimeType = new System.Net.Mime.ContentType("text/html");
        			
        // Add the alternate body to the message.    			
        AlternateView alternate = AlternateView.CreateAlternateViewFromString(mailMessage.Body, mimeType);
        mailMessage.AlternateViews.Add(alternate);

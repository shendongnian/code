        using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using Microsoft.Exchange.WebServices.Data;
    
    public class Exchange
    {
    
    	public void SendEmail(string fromEmailAddress, string toEmailAddress, string body, string subject)
    	{
    
    		dynamic exService = new ExchangeService(serverVersion);
    		exService.AutodiscoverUrl(fromEmailAddress);
    
    
    		EmailMessage msg = new EmailMessage(exService);
    		msg.Subject = subject;
    
    		msg.Body = body;
    
    		msg.ToRecipients.Add(new Microsoft.Exchange.WebServices.Data.EmailAddress(toEmailAddress, toEmailAddress));
    
    		msg.SendAndSaveCopy();
    
    	}
    }

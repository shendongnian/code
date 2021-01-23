      ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010);
            service.Url = new Uri("https://<server>/EWS/Exchange.asmx");
            EmailAddress emailAddress = new EmailAddress();
            emailAddress.Address = "nick.wright@<domain>";
            emailAddress.Name = String.Empty;
            OofSettings OOFSettings = new OofSettings();
            OOFSettings.Duration = new TimeWindow(DateTime.Now, DateTime.Now.AddDays(1));
            OOFSettings.ExternalAudience = OofExternalAudience.All;
            OofReply internalReply = new OofReply();
            OofReply externalReply = new OofReply();
            externalReply.Message = "This is my external OOF reply";
            internalReply.Message = "This is my internal OOF reply";
            OOFSettings.ExternalReply = externalReply;
            OOFSettings.InternalReply = internalReply;
            OOFSettings.State = OofState.Disabled;
            
            try
            {
                service.SetUserOofSettings("nick.wright@<domain>", OOFSettings);
            }
            catch (Exception ex)
            {
            }

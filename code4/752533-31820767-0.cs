    public string[] GetCCAddress(MailItem mailItem)
        {
            string email;
            Outlook.ExchangeUser exUser;
            List <string> ccEmailAddressList = new List<string>();
            foreach (Recipient recip in mailItem.Recipients)
            {
                if ((OlMailRecipientType)recip.Type == OlMailRecipientType.olCC)
                {
                        email=recip.Address;
                        if (!email.Contains("@"))
                        {
                            exUser = recip.AddressEntry.GetExchangeUser();
                            email = exUser.PrimarySmtpAddress;
                        }
                        ccEmailAddressList.Add(email);
                    
                }
            }

            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010);
            service.Credentials = new WebCredentials("uname", "password", "domain");
            service.Url = new Uri("URL");
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false));
            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, searchFilter, new ItemView(int.MaxValue));
                foreach (EmailMessage item in findResults.Items)
                {
                        item.Load();
                        if (item.HasAttachments)
                        {
                            foreach (var i in item.Attachments)
                            {
                                try
                                {
                                    FileAttachment fileAttachment = i as FileAttachment;
									 fileAttachment.Load("C:\\Users\\xxxxx\\Desktop\\comstar\\Download\\test\\" + fileAttachment.Name);
                                }
                                   
                                catch(Exception e)
                                {
                                    Console.Write(e);
                                }
                            }
                        }
						//set mail as read 
                        item.IsRead = true;
                        item.Update(ConflictResolutionMode.AutoResolve);
                    }
               
		}
              

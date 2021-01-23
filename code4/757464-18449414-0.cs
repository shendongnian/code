            // Connect to Exchange Web Services
            service = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
            service.Credentials = new WebCredentials("svc_user", "svc_password", "domain");
            service.AutodiscoverUrl("user@domain");
            service.ImpersonatedUserId = new ImpersonatedUserID(ConnectingIdType.SmtpAddres, "user@domain");
            //Return count
            ItemView view = new ItemView(10);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Calendar, view);
            MessageBox.Show(findResults.Count().ToString());

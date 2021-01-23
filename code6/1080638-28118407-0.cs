         static void Main(string[] args)
        {
            ExchangeService service = new ExchangeService  (ExchangeVersion.Exchange2010_SP2);
            //***********New**********************
            ExchangeService  mailbox = new ExchangeService(ExchangeVersion.Exchange2010_SP2); 
            string mailboxEmail = ConfigurationSettings.AppSettings["user-id"]; 
            WebCredentials wbcred = new WebCredentials(ConfigurationSettings.AppSettings["user"], ConfigurationSettings.AppSettings["PWD"]); 
            mailbox.Credentials = wbcred;
        //    mailbox.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, mailboxEmail);
           
              mailbox.AutodiscoverUrl(mailboxEmail,  RedirectionUrlValidationCallback);
            mailbox.HttpHeaders.Add("X-AnchorMailBox", mailboxEmail);
            FolderId mb1Inbox = new FolderId(WellKnownFolderName.Inbox, mailboxEmail);
             SetStreamingNotification(mailbox, mb1Inbox);
             bool run = true;
            while (run)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
        internal static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            //The default for the validation callback is to reject the URL
            bool result=false;
            Uri redirectionUri=new Uri(redirectionUrl);
            if(redirectionUri.Scheme=="https")
            {
                result=true;
            }
            return result;
        }
        static void SetStreamingNotification(ExchangeService service,FolderId fldId)
        {
            StreamingSubscription streamingssubscription=service.SubscribeToStreamingNotifications(new FolderId[]{fldId},
                EventType.NewMail,
                EventType.Created,
                EventType.Deleted);
            StreamingSubscriptionConnection connection=new StreamingSubscriptionConnection(service,30);
            connection.AddSubscription(streamingssubscription);
            //Delagate event handlers
            connection.OnNotificationEvent+=new StreamingSubscriptionConnection.NotificationEventDelegate(OnEvent);
            connection.OnSubscriptionError+=new StreamingSubscriptionConnection.SubscriptionErrorDelegate(OnError);
            connection.Open();
        }
        static void OnEvent(object sender,NotificationEventArgs args)
        {
            StreamingSubscription subscription=args.Subscription;
            if(subscription.Service.HttpHeaders.ContainsKey("X-AnchorMailBox"))
            {
                Console.WriteLine("event for nailbox"+subscription.Service.HttpHeaders["X-AnchorMailBox"]);
            }
            //loop through all the item-related events.
            foreach(NotificationEvent notification in args.Events)
            {
                switch(notification.EventType)
                {
                    case EventType.NewMail:
                        Console.WriteLine("\n----------------Mail Received-----");
                        break;
                    case EventType.Created:
                        Console.WriteLine("\n-------------Item or Folder deleted-------");
                        break;
                    case EventType.Deleted:
                        Console.WriteLine("\n------------Item or folder deleted---------");
                        break;
                }
                //Display notification identifier
                if(notification is ItemEvent)
                {
                    //The NotificationEvent for an email message is an ItemEvent
                    ItemEvent itemEvent=(ItemEvent)notification;
                    Console.WriteLine("\nItemId:"+ itemEvent.ItemId.UniqueId);
                    Item NewItem=Item.Bind(subscription.Service,itemEvent.ItemId);
                    if(NewItem is EmailMessage)
                    {
                        Console.WriteLine(NewItem.Subject);
                    }
                }
                else
                {
                    //the Notification for a Folder is an FolderEvent
                    FolderEvent folderEvent=(FolderEvent)notification;
                    Console.WriteLine("\nFolderId:"+folderEvent.FolderId.UniqueId);
                }
            }
        }
        static void OnError(object sender,SubscriptionErrorEventArgs args)
        {
            //Handle error conditions.
            Exception e=args.Exception;
            Console.WriteLine("\n-----Error-----"+e.Message+"--------");
        }
    }
}

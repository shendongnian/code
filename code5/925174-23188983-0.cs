        public YourViewModel()
        {           
            RegisterToReceiveMessages(MessageTokens.SomeToken, OnChangeCallYourMethodToAddress); //The MessageTokens is something you generally create ur self.
        }
        
        #region Notifications
        void OnChangeCallYourMethodToAddress(object sender, NotificationEventArgs<SlideShowLocale> e)
        {
            SomeProperty = e.Data;
        }

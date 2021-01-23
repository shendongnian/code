    List<EmailAddress> lstEmailAddress = new List<EmailAddress>();
    private void TimerCheckInternetConnection_Tick(object sender, EventArgs e)
    {
        // remove this lock as we have another in Email class
        //lock (TicketLock)
        if (UtilityManager.CheckForInternetConnection())
        {
            if (ApplicationRunStatus == Enum_ApplicationRunStatus.UnknownDisconnect
              || ApplicationRunStatus == Enum_ApplicationRunStatus.IsReady)
            {
                for (int i = 0; i < lstEmailAddress.Count; i++)
                {
                    // use local variable to store index
                    int localIndex = i;
                    // Connect
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        // if you add a lock here, this will run synchroniosly,
                        // and you aren't really need the ThreadPool
                        //lock (TicketLock)
                        lstEmailAddress[localIndex].IsActive = lstEmailAddress[localIndex].Login();
                        this.BeginInvoke(new Action(() =>
                        {
                            // some code
                        }));
                    });
                }
            }
        }
    }
    class EmailAddress
    {
        // if you have to login only for one user simultaneosly
        // use static variables here, other wise simply remove the lock as it is useless
        private static Imap4Client imap;
    
        private static object objectLock;
        // static constructor for only one initialization for a static fields
        static EmailAddress()
        {
            objectLock = new object();
            imap = new Imap4Client();
        }
    
        public bool IsActive;
        public string Address;
        public string Password;
    
        public string RecieveServerAddress;
        public int RecieveServerPort;
    
        public bool Login()
        {
            // aquire a static lock
            lock (objectLock)
            {
                try
                {
                    imap.ConnectSsl(RecieveServerAddress, RecieveServerPort);
                }
                catch (Exception)
                {
                    // STORE THE EXCEPTION!!!
                    // return as you haven't connected
                    return false;
                }
    
                try
                {
                    imap.Login(Address, Password);
                    return true;
                }
                catch (Exception)
                {
                    // STORE THE EXCEPTION!!!
                    return false;
                }
            }
    
        }
    }

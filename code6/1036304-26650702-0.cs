    public class ManageNotificationUtil
    {
        private BackgroundWorker NotificationWorker;
        private Timer timerNotification;
        private Form ParentForm;
        private NotificationDetailData NotificationDetail;
        public ManageNotificationUtil()
        {
            //NotificationWorker = new System.ComponentModel.BackgroundWorker();
            //timerNotification = new Timer();
            //NotificationWorker.RunWorkerAsync();
            //InitializeComponent();
        }
        public ManageNotificationUtil(Form owner)
        {
            ParentForm = owner;
            NotificationWorker = new System.ComponentModel.BackgroundWorker();
            NotificationWorker.RunWorkerAsync();
            timerNotification = new Timer();
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.timerNotification.Enabled = true;
            this.timerNotification.Interval = 60000;
            this.timerNotification.Tick += new EventHandler(timerNotification_Tick);
            this.NotificationWorker.DoWork += new DoWorkEventHandler(NotificationWorker_DoWork);
            NotificationWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(NotificationWorker_RunWorkerCompleted);
        }
        private void NotificationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            NotificationDetail = NotificationBD.GetNotificationDataByReceiverUserName(SessionManagerUI.UserSessionDetails.UserDetails.LoginUserName);
        }
        private void NotificationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (NotificationDetail != null)
            {
                if (NotificationDetail.NotificationList != null)
                {
                    if (NotificationDetail.NotificationList.Count > 0)
                    {
                        NotificationAlertControlUtility notificationAlertControlUtility;
                        foreach (NotificationData Notification in NotificationDetail.NotificationList)
                        {
                            notificationAlertControlUtility = new NotificationAlertControlUtility(Notification);
                            notificationAlertControlUtility.AlertControlShowConformation(ParentForm);
                        }
                    }
                }
            }
        }
        private void timerNotification_Tick(object sender, EventArgs e)
        {
            if (!NotificationWorker.IsBusy && SessionManagerUI.SessionDetails != null)
            {
                NotificationWorker.RunWorkerAsync(0);
            }
        }
        public void disposeItems()
        {
        }
    }

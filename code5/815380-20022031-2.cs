        public Form1()
        {
            InitializeComponent();
            PopupManager.PopupClosed += PopupManager_PopupClosed;
            PopupManager.PopupOpened += PopupManager_PopupOpened;
        }
        void PopupManager_PopupOpened(object sender, PopupStateChangedEventArgs e)
        {
            MessageBox.Show(e.Popup.Caption + " was opened");
        }
        void PopupManager_PopupClosed(object sender, PopupStateChangedEventArgs e)
        {
            MessageBox.Show(e.Popup.Caption + " was closed");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PopupForm popup = new PopupForm("TestPopup");
            popup.Show();
        }

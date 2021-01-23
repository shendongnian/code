    public partial class FormTray : Form
    {
        private static _instance;
        public static Instance { get { return _instance; } } // to get from anywhere
        public FormTray()
        {
            InitializeComponents();
            _instance = this; // store instance
        }
        private void OpenSettings(object sender, EventArgs e)
        {
            FormSettings.Show(); // call static method 
        }
        private void OpenLog(object sender, EventArgs e)
        {
            FormLog.Show(); // call static method
        }
        
        // ...
    }
    public partial class FormSettings
    {
        private static FormSettings _instance; // to be used from static methods
        public FormSettings()
        {
            InitializeComponents();
            _instance = this;
        }
        public static Show()
        {
            if(_instance == null) // not yet created - create and show
            {
                _instance = new FormSettings();
                _instance.Show();
            }
            else
                _instance.Visible = true; // was created and hidden - un-hide
        }
        void FormSettings_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true; // disable closing
            Visible = false; // hide instead
        }
        // ...
    }
    public partial class FormLog
    {
        // ... same as settings
        // static method for log messages
        public static AddMessage(string message)
        {
            if(FormTray.Instance != null && FormTray.Instance.IsHandleCreated) // avoid errors if attempting to log before main form is created
            {
                 if(FormTray.Instance.InvokeRequired)
                     FormTray.Instance.BeginInvoke(() = { AddMessage(message); } // need invoke
                 else
                 {
                     // ... logging here
                 }
            }
        }
    }

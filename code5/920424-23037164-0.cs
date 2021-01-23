    public partial class FormGApp : Form
    {
        private BackgroundWorker m_LoginBackgroundWorker;
    
        // ctor:
        public FormGApp()
        {
             // init thread:
             this.m_LoginBackgroundWorker = new BackgroundWorker();
             this.m_LoginBackgroundWorker.DoWork += this.LoginBackgroundWorker_DoWork;
             this.m_LoginBackgroundWorker.RunWorkerCompleted += this.LoginBackgroundWorker_RunWorkerCompleted;
        }
    
        private void buttonLogin_Click(object sender, EventArgs e)
        {
             // start thread:
             this.m_LoginBackgroundWorker.RunWorkerAsync();
        }
    
        private void LoginBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
             this.login();
        }
    
        private void LoginBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             this.successfullyLogin();
        }
    
        private void login()
        {
             // code that take long time that executed in a separate thread... 
        }
    
        private void successfullyLogin()
        {
             // Gui WinForm update code here...
        }

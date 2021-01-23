       public partial class InnerForm : UserControl
     {
        MainForm theMain;
    
        public InnerForm(MainForm main)
        {
            InitializeComponent();
            theMain = main;
        }
    
        public InnerForm(string url, MainForm mainForm)
        {
            this.theMain = mainForm;
            InitializeComponent();
            // more code
        }
    
        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
           theMain.agregaRow(args);
        }
     }

    [Program.cs]
    static class Program
    {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
               var formMain = new Forms.FormMain();
               var splash = new Forms.FormSplash( formMain );
               splash.Show();
               Application.DoEvents();
               Application.Run( formMain );
            }
    }
    
    [FormMain.cs]
    public partial class FormMain : Form
    {
            public FormMain()
            {
                // This Form is initially invisible.
                // The splash screen Form is responsible to making this form visible.
                //
                this.Opacity = 0;
    
                InitializeComponent();
            }
    }
    
    [FormSplash.cs]
        public partial class FormSplash : Form
        {
            Forms.FormMain _theMainForm;
    
            public FormSplash()
            {
                InitializeComponent();
    
                // ctlLogoText is a RichTextBox control.
                //
    
                this.ctlLogoText.BorderStyle = BorderStyle.None;
                this.ctlLogoText.Rtf = SR.LogoText;
            }
    
            public FormSplash( Forms.FormMain theMainForm )
                : this()
            {
                _theMainForm = theMainForm;
    
                Application.Idle += new EventHandler( Application_Idle );
            }
    
            void Application_Idle( object sender, EventArgs e )
            {
                Application.Idle -= new EventHandler( Application_Idle );
    
                if ( null != _theMainForm )
                {
                    // theTimer is a System.Windows.Forms.Timer.
                    //
                    this.theTimer.Interval = Math.Min( 5000, Math.Max( 1000, 1000 * Settings.Default.SplashDelay ) );
                    this.theTimer.Start();
                }
            }
    
            void theTimer_Tick( object sender, EventArgs e )
            {
                this.theTimer.Stop();
                this.Close();
    
                Application.DoEvents();
    
                _theMainForm.Opacity = 100;
                _theMainForm.Refresh();
                _theMainForm = null;
            }
        }

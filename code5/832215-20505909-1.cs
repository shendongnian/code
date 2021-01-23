    namespace  WindowsForm1
    {
        public enum SplashTypeOfMessage
        {   Success,    
            Warning,
            Error       
        }
    
        public partial class SplashForm : Form
        {
            static SplashForm _splashForm = null;
            static Thread _splashThread = null;
            public static object locker = new object(); 
            public  static bool WaitPlease = true;  
        
            private  SplashForm()
            {
                InitializeComponent();
                lblLoading.Text = "Please wait Loading";
            }
        
            public static  void ShowSplashScreen()
            {            
                if (_splashForm != null)
                    return;
                _splashThread = new Thread(new ThreadStart(SplashForm.ShowSplash));
                _splashThread.IsBackground = true; 
                _splashThread.SetApartmentState(ApartmentState.STA) ; 
                _splashThread.Start();
            }
        
            public static void ShowSplash()
            {
                if (_splashForm==null)
                {                
                    _splashForm = new SplashForm();
                    _splashForm.blueLoaderBar1.StartAnimation();
                   
                }
                  _splashForm.TopMost = true;
                  _splashForm.Show();
                  lock (SplashForm.locker)
                  {
                      WaitPlease = false;
                  }
                      
                Application.Run(_splashForm);
                
            }
        
            delegate void CloseSplashHandler(SplashTypeOfMessage typeOfMessage, string message,bool itWasRinvoked);
        
            public static void CloseSplash(SplashTypeOfMessage typeOfMessage,string message,bool itWasrinvoked)
            {                             
                CloseSplashHandler closeSpalshHandler = new CloseSplashHandler(CloseSplash);
                bool launched=false;
                while (!launched && !itWasrinvoked)
                {
                    lock (SplashForm.locker)
                    {
                        if (!SplashForm.WaitPlease)
                        {
                            launched = true;
                        }
                    }
                 }
    
                if (_splashForm!=null && _splashThread!=null )
                {
                    if (_splashForm.InvokeRequired)
                    {
                        _splashForm.Invoke(closeSpalshHandler,new object[] {typeOfMessage,message,true});
                    }
                    else
                    {                    
                        switch (typeOfMessage)
                        {
                            case SplashTypeOfMessage.Warning:
                                break;
                            case SplashTypeOfMessage.Error:
                                MessageBox.Show("Error");                                                  
                                break;
                            default:
                                break;
                        }
                        _splashForm.Close();
                        _splashThread = null;
                        
                    }                                
                }
            }             
        }
    }

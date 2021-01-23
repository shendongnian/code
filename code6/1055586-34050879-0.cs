    public partial class Form1 : Form
        {
            private IDisposable server;
    
            public Form1()
            {
                InitializeComponent();
                InitializeOwin();
            }
    
            private void InitializeOwin()
            {
                server = WebApp.Start<OwinStartup>("http://localhost:8989/");
            }
    
            /// <summary>
            /// To be called before quit or stop button
            /// </summary>
            private void CallMeBeforeClose()
            {
                server.Dispose();
            }
        }
    
        public class OwinStartup
        {
            //initialize owin startup class and do other stuff
            public void Configuration(IAppBuilder appBuilder)
            {
                appBuilder.UseWelcomePage("/");
            }
        }

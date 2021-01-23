    public class CommunicationObject
    {
        // you will probably have several EventArgs to define to pass extra info
        public event EventHandler<EventArgs> Connected;
        // you need this instance to dispatch events to the UI thread
        private Control _invoker;
        public CommunicationObject(Control invoker)
        {
           _invoker = invoker;
           // start a thread here, or better yet, add an Enabled property or
           //   Start method to kick it off
        }
        // from the thread that is doing the real work, call this when you are connected 
        private void OnConnected()
        {
        
            _invoker.Invoke(() => 
            { 
            
                EventHandler<EventArgs> handler = Connected;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty); // eventually you might need your own event args
                }
            });
        }
    }
    public class Form1 : Form
    {
        private CommunicationObject _comm;
 
        public Form1()
        {
            InitializeComponent();
    
            imgLoading.Show(); // show msg until connected
            _comm = new CommunicationObject(this);
            _comm.Connected += Comm_Connected; // wire up event handler
        }
        private void Comm_Connected(object src, EventArgs e)
        {
            if (imgLoading.Visible)
            {
                imgLoading.Hide(); // hide once connected
            }
            panelMENUshow(); 
        } 
    }

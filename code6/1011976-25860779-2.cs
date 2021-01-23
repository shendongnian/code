    public class Example
    {
        /// <summary>
        /// External method for checking internet access:
        /// </summary>
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        /// <summary>
        /// C# callable method to check internet access
        /// </summary>
        public static bool IsConnectedToInternet()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }
        private static Timer aTimer;
        /// <summary>
        /// Fired when a connection is made to the server
        /// </summary>
        public event EventHandler ConnectedToNetwork;
        public void OnConnected()
        {
            try
            {
                if (null != ConnectedToNetwork)
                {
                    ConnectedToNetwork(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// Fired when ADVIA QC loses its connection to the server
        /// </summary>
        public event EventHandler DisconnectedFromNetwork;
        /// <summary>
        /// Clears server notifications
        /// </summary>
        public void OnDisconnected()
        {
            try
            {
                if (null != DisconnectedFromNetwork)
                {
                    DisconnectedFromNetwork(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Intialize()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000); //Timer will start when your application is started
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program... ");
            Console.ReadLine();
            Console.WriteLine("Terminating the application...");
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (IsConnectedToInternet())
            {
                OnConnected();
                //Code to APP will wake up and execute SQL commands.
            }
            else
            {
                OnDisconnected();
            }
        }
    }
    class DBClass
    {
        //In DB area
        private void ClientCodeSubscription()
        {
            Example ex = new Example();
            ex.ConnectedToNetwork += Example_ConnectedToNetwork; //this is your client code probably in this case the DB
        }
        static void Example_ConnectedToNetwork(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
